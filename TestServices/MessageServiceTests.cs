using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Models;
using TestHelpers;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Communication.DTOs.Games;
using Communication.DTOs.Message;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestServices
{
    public class MessageServiceTests : ServiceTestBase<MessageService>
    {
        private readonly Mock<ILogger<MessageService>> _logger = new Mock<ILogger<MessageService>>();

        public MessageServiceTests():base()
        {
            _sut = new MessageService(_serviceCollection.BuildServiceProvider(),_logger.Object);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(1000)]
        public async Task GetAllMessagesAsync_DifferentScenarios(int itemsCount)
        {

            // Attach
            var matchResultMessages = GenerateMatchResultMessages(itemsCount);
            var newChellangeMessages = GenerateNewChellangeMessages(itemsCount);

            await _testContext.MatchResultMessages.AddRangeAsync(matchResultMessages);
            await _testContext.NewChellangeMessages.AddRangeAsync(newChellangeMessages);
            await _testContext.SaveChangesAsync();

            // Act
            var getAllGamesResult = await _sut.GetMessages();

            // Assert
            Assert.Equal(2*itemsCount, getAllGamesResult.Count());
            Assert.All(getAllGamesResult, mrm => matchResultMessages.Any(p => p.Content == mrm.Content));
            Assert.All(getAllGamesResult, ncm => newChellangeMessages.Any(p => p.Content == ncm.Content));
        }

        private static List<MatchResultMessage> GenerateMatchResultMessages(int count)
        {
            int currentPossition = 0;
            var generator = new Faker<MatchResultMessage>()
                .RuleFor(p => p.Content, f => f.Lorem.Text())
                .RuleFor(p => p.Date, f => f.Date.Past(1))
                .RuleFor(p=>  p.RelatedPositionUpdates, new List<LeaguePositions>());

            return generator.Generate(count);
        }

        private static List<NewChellangeMessage> GenerateNewChellangeMessages(int count)
        {
            int currentPossition = 0;
            var generator = new Faker<NewChellangeMessage>()
                .RuleFor(p => p.Content, f => f.Lorem.Text())
                .RuleFor(p => p.Date, f => f.Date.Past(1));

            return generator.Generate(count);
        }
    }
}
