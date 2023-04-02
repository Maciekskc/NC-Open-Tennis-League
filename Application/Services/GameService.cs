using Application.DTOs.Games;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Persistance.Models;

namespace Application.Services;

public class GameService : BaseService, IGameService
{
    public GameService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<Game> CreateAsync(CreateGameDto gameDto)
    {
        var game = new Game()
        {
            GameId = Guid.NewGuid(),
            ChallengeDate = gameDto.ChallengeDate,
            ChallengedPlayerId = gameDto.ChallengedPlayerId,
            ChallengingPlayerId = gameDto.ChallengingPlayerId,
            MatchDate = gameDto.MatchDate,
        };
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
        await DbContext.Games.Select(g => new GameViewDto
        { 
            ChallengedPlayerName = g.ChallengedPlayer.Initials,
            ChallengingPlayerName = g.ChallengingPlayer.Initials,
            ChallengeDate = g.ChallengeDate,
            MatchDate = g.MatchDate,
            
        }).ToListAsync();

    public async Task<GameViewDto?> GetViewModelByIdAsync(Guid id)
    {
        var game = await DbContext.Games.FindAsync(id);
        if (game != null)
            return new GameViewDto
            {
                ChallengedPlayerName = game.ChallengedPlayer.Initials,
                ChallengingPlayerName = game.ChallengingPlayer.Initials,
                ChallengeDate = game.ChallengeDate,
                MatchDate = game.MatchDate
            };
        return null;
    }

    public async Task<Game?> GetByIdAsync(Guid id) => 
        await DbContext.Games.FindAsync(id);

    public Task UpdateAsync(Guid id, GameViewDto gameDto)
    {
        throw new NotImplementedException();
    }

    Task<List<GameViewDto>> IGameService.GetAllPlayerGamesAsync(Guid PlayerId)
    {
        throw new NotImplementedException();
    }
}
