using Communication.DTOs.Games;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Models;

namespace Infrastructure.Services;

public class GameService : BaseService, IGameService
{
    public GameService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<Game> CreateAsync(CreateGameDto gameDto)
    {
        var game = Mapper.CreateGameDtoToGame(gameDto);
        game.GameId = Guid.NewGuid();
        DbContext.Add(game);

        var challengingPlayer = DbContext.Players.FirstOrDefault(p => p.Id == game.ChallengingPlayerId);
        var chellengedPlayer = DbContext.Players.FirstOrDefault(p => p.Id == game.ChallengedPlayerId);
        var message = new NewChellangeMessage()
        {
            GameId = game.GameId,
            Content = $"""
            {challengingPlayer.Initials} from position {challengingPlayer.CurrentPosition} challenged {chellengedPlayer.Initials}.\n
            On {game.MatchDate.ToString() ?? "<will be assigned later>"} they will fight for {chellengedPlayer.CurrentPosition} position in clasification. \n
            Good luck!
            """
        };
        DbContext.Add(message);

        await DbContext.SaveChangesAsync();
        return await DbContext.Games.FindAsync(game.GameId);
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GameViewDto>> GetAllAsync() =>
       await DbContext.Games
        .Include(g => g.ChallengedPlayer)
        .Include(g => g.ChallengingPlayer)
        .Select(game => Mapper.GameToGameViewGameDto(game)).ToListAsync();

    public async Task<GameViewDto?> GetViewModelByIdAsync(Guid id)
    {
        var game = await DbContext.Games.FindAsync(id);
        if (game != null)
            return Mapper.GameToGameViewGameDto(game);
        return null;
    }

    public async Task<Game?> GetByIdAsync(Guid id) => 
        await DbContext.Games.FindAsync(id);

    public Task UpdateAsync(Guid id, GameViewDto gameDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<GameViewDto>> GetAllPlayerGamesAsync(Guid PlayerId)
    {
        throw new NotImplementedException();
    }

    public async Task FinalizeGameAsync(FinalizeGameDto finalizeGameDto)
    {
        // Retrieve the game object from the database using the game ID
        var game = await DbContext.Games
            .Include(g => g.ChallengingPlayer)
            .Include(g => g.ChallengedPlayer)
            .FirstOrDefaultAsync(g => g.GameId == finalizeGameDto.GameId);

        if (game == null)
        {
            throw new ArgumentException($"Game with ID {finalizeGameDto.GameId} not found.");
        }



        // Set the match date
        game.MatchDate = finalizeGameDto.MatchDate;

        string matchResultMessageContent = string.Empty;


        // Determine the winner and update the win property
        EvaluateMatchResult(finalizeGameDto, game);
        if (game.Win.Value)
        {
            matchResultMessageContent += $"On {game.MatchDate.ToString()} {game.ChallengingPlayer.Initials} beat {game.ChallengedPlayer.Initials} and gains {GetOrdinalNumber(game.ChallengedPlayer.CurrentPosition)} position!\n";
            
            var playersToUpdate = GetPlayersForPossitionUpdate(game.ChallengingPlayer.CurrentPosition, game.ChallengedPlayer.CurrentPosition);
            matchResultMessageContent += GetPositionUpdatesForMatchResultMessage(playersToUpdate);
            UpdatePlayerPossitions(game.ChallengingPlayer, game.ChallengedPlayer.CurrentPosition,playersToUpdate);

        }
        else
        {
            matchResultMessageContent += $"On {game.MatchDate.ToString()} {game.ChallengedPlayer.Initials} beat {game.ChallengingPlayer.Initials} and defended {GetOrdinalNumber(game.ChallengedPlayer.CurrentPosition)} position!\n";
        }

        // Set the walkover property
        game.Walkover = finalizeGameDto.Walkover;

        // Set the gems count for both players
        game.ChallengingPlayerWonGemsCount = finalizeGameDto.ChallengingPlayerWonGemsCount;
        game.ChallengedPlayerWonGemsCount = finalizeGameDto.ChallengedPlayerWonGemsCount;

        // Save changes to the database
        DbContext.Update(game);
        var message = new MatchResultMessage()
        {
            GameId = game.GameId,
            Content = matchResultMessageContent
        };
        DbContext.Add(message);

        await DbContext.SaveChangesAsync();
    }


    /// <summary>
    /// Retrn information about players that lose position
    /// </summary>
    /// <param name="playersToUpdate"></param>
    /// <returns></returns>
    private string GetPositionUpdatesForMatchResultMessage(List<TennisPlayer> playersToUpdate)
    {
        if (playersToUpdate.Count == 1)
            return $"{playersToUpdate.First().Initials} falls down one position.";

        return string.Join(',', playersToUpdate.Select(p => p.Initials).ToList()) + " falls down one position.";
    }

    /// <summary>
    /// Method that returns ordinal numerator for match result message
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private string GetOrdinalNumber(int num)
    {
        if (num <= 0)
        {
            throw new ArgumentException("Number must be greater than zero.", nameof(num));
        }

        switch (num % 100)
        {
            case 11:
            case 12:
            case 13:
                return num + "th";
            default:
                switch (num % 10)
                {
                    case 1:
                        return num + "st";
                    case 2:
                        return num + "nd";
                    case 3:
                        return num + "rd";
                    default:
                        return num + "th";
                }
        }
    }

    /// <summary>
    /// Update positions after won challenge
    /// </summary>
    /// <param name="challengingPlayerId"></param>
    /// <param name="challengedPlayerId"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void UpdatePlayerPossitions(TennisPlayer winner, int position, List<TennisPlayer> playersToUpdate)
    {
        winner.CurrentPosition = position;
        DbContext.Update(winner);

        foreach (var player in playersToUpdate)
        {
            player.CurrentPosition++;
            DbContext.Update(player);
        }
    }

    private List<TennisPlayer> GetPlayersForPossitionUpdate(int challengingPlayerPosition, int challengedPlayerPosition) =>
        DbContext.Players.Where(p => p.CurrentPosition < challengingPlayerPosition && p.CurrentPosition >= challengedPlayerPosition).ToList();

    /// <summary>
    /// Check who won the game
    /// </summary>
    /// <param name="finalizeGameDto"></param>
    /// <param name="game"></param>
    private static void EvaluateMatchResult(FinalizeGameDto finalizeGameDto, Game? game)
    {
        if (finalizeGameDto.ChallengingPlayerWonGemsCount > finalizeGameDto.ChallengedPlayerWonGemsCount)
        {
            game.Win = true;
        }
        else if (finalizeGameDto.ChallengedPlayerWonGemsCount > finalizeGameDto.ChallengingPlayerWonGemsCount)
        {
            game.Win = false;
        }
        else
        {
            game.Win = null;
        }
    }
}
