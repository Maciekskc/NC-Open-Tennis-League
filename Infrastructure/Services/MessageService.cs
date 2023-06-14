using Communication.DTOs.Message;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistance.Models;

namespace Infrastructure.Services;

public class MessageService : BaseService<MessageService>, IMessageService
{
    public MessageService(IServiceProvider serviceProvider, ILogger<MessageService> logger) : base(serviceProvider, logger)
    {
    }

    public async Task<List<RankingUpdateMessage>> GetMessages()
    {
        var matchResults = await DbContext.MatchResultMessages.Select(m => Mapper.MatchResultMessageToRankingUpdateMessage(m)).ToListAsync();
        var matchChellanges = await DbContext.NewChellangeMessages
                                    .Where(m => m.GetType() == typeof(NewChellangeMessage))
                                    .Select(m => Mapper.NewChellangeMessageToRankingUpdateMessage(m))
                                    .ToListAsync();

        var messages = matchResults.Concat(matchChellanges);
        return SortMassages(messages);
    }

    private List<RankingUpdateMessage> SortMassages(IEnumerable<RankingUpdateMessage> messages) => messages.OrderBy(message => message.Date).ToList();
}
