using Communication.DTOs.TennisPlayer;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Models;
using TestHelpers;

namespace TestServices 
{
    public class TennisPlayerServiceTests : ServiceTestBase<TennisPlayerService>
    {
        public TennisPlayerServiceTests():base()
        {
            _sut = new TennisPlayerService(_serviceCollection.BuildServiceProvider());
        }

        [Fact]
        public async Task CreateAsync_ProperData_PlayerCreated()
        {
            // Attach
            var requestPlayer = new CreateTennisPlayerRequest { Initials = "ABCD" };

            // Act
            var response = await _sut.CreateAsync(requestPlayer);

            // Assert
            Assert.Equal(_testContext.Players.SingleOrDefault().Initials, requestPlayer.Initials);
        }

        [Fact]
        public async Task DeleteAsync_ProperData_PlayerCreated()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var requestPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1 };

            await _testContext.Players.AddAsync(requestPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act
            await _sut.DeleteAsync(playerId);

            // Assert
            Assert.NotEqual(tennisPlayerInitialCount, _testContext.Players.Count());
            Assert.Null(_testContext.Players.FirstOrDefault());
        }

        [Fact]
        public async Task DeactivatePlayerAsync_ProperData_PlayerCreated()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var requestPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1, IsActive = true };

            await _testContext.Players.AddAsync(requestPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act
            await _sut.DeactivatePlayerAsync(playerId);

            // Assert
            Assert.Equal(tennisPlayerInitialCount, _testContext.Players.Count());
            Assert.NotNull(_testContext.Players.FirstOrDefault());
            Assert.False(_testContext.Players.FirstOrDefault().IsActive);
        }

        [Fact]
        public async Task ActivatePlayerAsync_ProperData_PlayerCreated()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var requestPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1, IsActive=false };

            await _testContext.Players.AddAsync(requestPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act
            await _sut.ActivatePlayerAsync(playerId);

            // Assert
            Assert.Equal(tennisPlayerInitialCount, _testContext.Players.Count());
            Assert.NotNull(_testContext.Players.FirstOrDefault());
            Assert.True(_testContext.Players.FirstOrDefault().IsActive);
        }
    }
}
