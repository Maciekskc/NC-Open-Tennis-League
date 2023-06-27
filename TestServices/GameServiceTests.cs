using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Models;
using TestHelpers;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Communication.DTOs.Games;
using Moq;
using Microsoft.Extensions.Logging;

namespace TestServices
{
    public class GameServiceTests : ServiceTestBase<GameService>
    {
        private readonly Mock<ILogger<GameService>> _logger = new Mock<ILogger<GameService>>();

        public GameServiceTests():base()
        {
            _sut = new GameService(_serviceCollection.BuildServiceProvider(), _logger.Object);
            _testContext.Players.AddRangeAsync(GeneratePlayers(10)).GetAwaiter().GetResult();
            _testContext.SaveChangesAsync().GetAwaiter().GetResult();
        }

        [Fact]
        public async Task CreateAsync_ProperData_GameCreated()
        {
            // Attach
            var players = await _testContext.Players.Take(2).ToListAsync();

            var createGameRequest = new CreateGameRequest {
                ChallengeDate = DateTime.Now,
                MatchDate = DateTime.Now.AddDays(1),
                ChallengedPlayerId = players[0].Id,
                ChallengingPlayerId = players[1].Id,
            };

            // Act
            var response = await _sut.CreateAsync(createGameRequest);
            var gameFromDatabase = _testContext.Games.SingleOrDefault();

            // Assert
            Assert.NotNull(gameFromDatabase);
            Assert.Equal(gameFromDatabase.ChallengeDate, createGameRequest.ChallengeDate);
            Assert.Equal(gameFromDatabase.MatchDate, createGameRequest.MatchDate);
            Assert.Equal(gameFromDatabase.ChallengedPlayerId, createGameRequest.ChallengedPlayerId);
            Assert.Equal(gameFromDatabase.ChallengingPlayerId, createGameRequest.ChallengingPlayerId);
        }

        [Fact]
        public async Task GetByIdAsync_ExistingGameId_GameReturned()
        {
            // Attach
            var game = GenerateGames(1).First();

            await _testContext.Games.AddAsync(game);
            await _testContext.SaveChangesAsync();

            // Act
            var getGameResult = await _sut.GetByIdAsync(game.GameId);

            // Assert
            Assert.Equal(game, getGameResult);
        }

        [Fact]
        public async Task GetViewModelByIdAsync_ExistingGameId_GameReturned()
        {
            // Attach
            var game = GenerateGames(1).First();

            await _testContext.Games.AddAsync(game);
            await _testContext.SaveChangesAsync();

            // Act
            var getGameResult = await _sut.GetViewModelByIdAsync(game.GameId);

            // Assert
            Assert.NotNull(getGameResult);
            Assert.Equal(getGameResult.ChallengeDate, game.ChallengeDate);
            Assert.Equal(getGameResult.MatchDate, game.MatchDate);
            Assert.Equal(getGameResult.Win, game.Win);
            Assert.Equal(getGameResult.Walkover, game.Walkover);
            Assert.Equal(getGameResult.ChallengedPlayerWonGemsCount, game.ChallengedPlayerWonGemsCount);
            Assert.Equal(getGameResult.ChallengedPlayerName, game.ChallengedPlayer.Initials);
            Assert.Equal(getGameResult.ChallengingPlayerWonGemsCount, game.ChallengingPlayerWonGemsCount);
            Assert.Equal(getGameResult.ChallengingPlayerName, game.ChallengingPlayer.Initials);
        }

        [Fact]
        public async Task GetByIdAsync_NotExistingGameId_ReturnNull()
        {
            // Attach
            var game = GenerateGames(1).First();

            await _testContext.Games.AddAsync(game);
            await _testContext.SaveChangesAsync();

            // Act
            var getGameResult = await _sut.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.Null(getGameResult);
            Assert.NotEmpty(_testContext.Games);
        }

        [Fact]
        public async Task FinalizeGameAsync_ProperData_GameFinalized()
        {
            // Attach
            var game = GenerateOngoingChallenge(1).First();
            await _testContext.Games.AddAsync(game);
            await _testContext.SaveChangesAsync();

            var finalizeGameRequest = new FinalizeGameRequest
            {
                GameId = game.GameId,
                MatchDate = DateTime.Now,
                ChallengedPlayerWonGemsCount = 4,
                ChallengingPlayerWonGemsCount = 6,
            };

            // Act
            await _sut.FinalizeGameAsync(finalizeGameRequest);

            // Assert
            var gameFromDatabase = _testContext.Games.SingleOrDefault(g => g.GameId == game.GameId);
            Assert.NotNull(gameFromDatabase);
            Assert.Equal(gameFromDatabase.ChallengeDate, game.ChallengeDate);
            Assert.Equal(gameFromDatabase.MatchDate, finalizeGameRequest.MatchDate);
            Assert.True(gameFromDatabase.Win);
            Assert.Equal(gameFromDatabase.ChallengedPlayerWonGemsCount, finalizeGameRequest.ChallengedPlayerWonGemsCount);
            Assert.Equal(gameFromDatabase.ChallengingPlayerWonGemsCount, finalizeGameRequest.ChallengingPlayerWonGemsCount);
        }

        [Fact]
        public async Task FinalizeGameAsync_GameDoesNotExist_ThrowArgumentException()
        {
            // Attach
            var game = GenerateOngoingChallenge(1).First();
            await _testContext.Games.AddAsync(game);
            await _testContext.SaveChangesAsync();

            var finalizeGameRequest = new FinalizeGameRequest
            {
                GameId = Guid.NewGuid(),
                MatchDate = DateTime.Now,
                ChallengedPlayerWonGemsCount = 4,
                ChallengingPlayerWonGemsCount = 6,
            };

            // Act Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.FinalizeGameAsync(finalizeGameRequest));
        }

        [Fact]
        public async Task DeleteAsync_NotImplementedException()
        {
            await Assert.ThrowsAsync<NotImplementedException>(() => _sut.DeleteAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task UpdateAsync_NotImplementedException()
        {
            await Assert.ThrowsAsync<NotImplementedException>(() => _sut.UpdateAsync(Guid.NewGuid(),new UpdateGameRequest()));
        }

        [Fact]
        public async Task GetAllPlayerGamesAsync_NotImplementedException()
        {
            await Assert.ThrowsAsync<NotImplementedException>(() => _sut.GetAllPlayerGamesAsync(Guid.NewGuid()));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(1000)]
        public async Task GetAllAsync_DifferentScenarios(int itemsCount)
        {

            // Attach
            var games = GenerateGames(itemsCount);

            await _testContext.Games.AddRangeAsync(games);
            await _testContext.SaveChangesAsync();

            // Act
            var getAllGamesResult = await _sut.GetAllAsync();

            // Assert
            Assert.Equal(itemsCount, getAllGamesResult.Count());
            Assert.All(getAllGamesResult, fp => games.Any(p => p.GameId == fp.GameId));
        }

        private List<Game> GenerateGames(int count)
        {
            int playerHelpPicker = 0;
            var players = _testContext.Players.ToList();

            var generator = new Faker<Game>()
                .RuleFor(p => p.GameId, f => Guid.NewGuid())
                .RuleFor(p => p.ChallengedPlayer, f => f.PickRandom(players))
                .RuleFor(p => p.ChallengingPlayer, f => f.PickRandom(players))
                .RuleFor(p => p.ChallengeDate, f => f.Date.Past(1))
                .RuleFor(p => p.MatchDate, f => f.Date.Between(DateTime.Now.AddDays(-10), DateTime.Now))
                .RuleFor(p => p.ChallengedPlayerWonGemsCount, f => f.Random.Number(6))
                .RuleFor(p => p.ChallengingPlayerWonGemsCount, f => f.Random.Number(6))
                .FinishWith((f, game) => game.Win = game.ChallengingPlayerWonGemsCount > game.ChallengedPlayerWonGemsCount);

            return generator.Generate(count);
        }

        private List<Game> GenerateOngoingChallenge(int count)
        {
            int playerHelpPicker = 0;
            var players = _testContext.Players.ToList();

            var generator = new Faker<Game>()
                .RuleFor(p => p.GameId, f => Guid.NewGuid())
                .RuleFor(p => p.ChallengedPlayer, f => f.PickRandom(players))
                .RuleFor(p => p.ChallengingPlayer, f => f.PickRandom(players))
                .RuleFor(p => p.ChallengeDate, f => f.Date.Past(1))
                .RuleFor(p => p.MatchDate, f => f.Date.Future(1));

            return generator.Generate(count);
        }

        private static List<TennisPlayer> GeneratePlayers(int count)
        {
            int currentPossition = 0;
            var generator = new Faker<TennisPlayer>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.CurrentPosition, f => currentPossition++)
                .RuleFor(p => p.Initials, f => f.Name.FirstName());

            return generator.Generate(count);
        }
    }
}
