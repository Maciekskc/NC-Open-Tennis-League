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
        public async Task GetById_ExistingPlayerId_PlayerReturned()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var expectedPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1 };

            await _testContext.Players.AddAsync(expectedPlayer);
            await _testContext.SaveChangesAsync();

            // Act
            var getPlayer = await _sut.GetByIdAsync(playerId);

            // Assert
            Assert.Equal(expectedPlayer.Id, getPlayer.PlayerId);
            Assert.Equal(expectedPlayer.Initials, getPlayer.Initials);
            Assert.Equal(expectedPlayer.CurrentPosition, getPlayer.Position);
        }

        [Fact]
        public async Task GetById_NotExistingPlayerId_ReturnNull()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var expectedPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1 };

            await _testContext.Players.AddAsync(expectedPlayer);
            await _testContext.SaveChangesAsync();

            // Act
            var getPlayer = await _sut.GetByIdAsync(Guid.NewGuid());

            // Assert
            Assert.Null(getPlayer);
            Assert.NotEmpty(_testContext.Players);
        }

        [Fact]
        public async Task UpdateAsync_ProperData_PlayerUpdated()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var existingPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1 };
            await _testContext.Players.AddAsync(existingPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            var updatePlayerRequest = new UpdateTennisPlayerRequest { Initials = "EFGH" };

            // Act
            await _sut.UpdateAsync(playerId, updatePlayerRequest);

            // Assert
            Assert.Equal(tennisPlayerInitialCount, _testContext.Players.Count());
            Assert.Equal(_testContext.Players.FirstOrDefault().Initials, updatePlayerRequest.Initials);
            Assert.Equal(_testContext.Players.FirstOrDefault().Id, playerId);
        }

        [Fact]
        public async Task UpdateAsync_PlayerDoesNotExist_ThrowArgumentException()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var existingPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1 };
            await _testContext.Players.AddAsync(existingPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            var updatePlayerRequest = new UpdateTennisPlayerRequest { Initials = "EFGH" };

            // Act Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.UpdateAsync(Guid.NewGuid(), updatePlayerRequest));
        }

        [Fact]
        public async Task DeleteAsync_ProperData_PlayerRemoved()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var testPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1 };

            await _testContext.Players.AddAsync(testPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act
            await _sut.DeleteAsync(playerId);

            // Assert
            Assert.NotEqual(tennisPlayerInitialCount, _testContext.Players.Count());
            Assert.Null(_testContext.Players.FirstOrDefault());
        }

        [Fact]
        public async Task DeleteAsync_PlayerDoesNotExist_ThrowArgumentException()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var testPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1 };

            await _testContext.Players.AddAsync(testPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.DeleteAsync(Guid.NewGuid()));
            Assert.Equal(tennisPlayerInitialCount, _testContext.Players.Count());
        }

        [Fact]
        public async Task DeactivatePlayerAsync_ProperData_PlayerDeactivated()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var testPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1, IsActive = true };

            await _testContext.Players.AddAsync(testPlayer);
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
        public async Task DeactivatePlayerAsync_PlayerDoesNotExist_ThrowArgumentException()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var testPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1, IsActive = true };

            await _testContext.Players.AddAsync(testPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.DeactivatePlayerAsync(Guid.NewGuid()));
            Assert.Equal(tennisPlayerInitialCount, _testContext.Players.Count());
        }

        [Fact]
        public async Task ActivatePlayerAsync_ProperData_PlayerActivated()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var testPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1, IsActive=false };

            await _testContext.Players.AddAsync(testPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act
            await _sut.ActivatePlayerAsync(playerId);

            // Assert
            Assert.Equal(tennisPlayerInitialCount, _testContext.Players.Count());
            Assert.NotNull(_testContext.Players.FirstOrDefault());
            Assert.True(_testContext.Players.FirstOrDefault().IsActive);
        }

        [Fact]
        public async Task ActivatePlayerAsync_PlayerDoesNotExist_ThrowArgumentException()
        {
            // Attach
            var playerId = Guid.NewGuid();
            var testPlayer = new TennisPlayer { Id = playerId, Initials = "ABCD", CurrentPosition = 1, IsActive = true };

            await _testContext.Players.AddAsync(testPlayer);
            await _testContext.SaveChangesAsync();
            var tennisPlayerInitialCount = _testContext.Players.Count();

            // Act Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.ActivatePlayerAsync(Guid.NewGuid()));
            Assert.Equal(tennisPlayerInitialCount, _testContext.Players.Count());
        }
    }
}
