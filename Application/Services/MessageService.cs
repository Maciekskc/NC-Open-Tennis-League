using Application.DTOs.Message;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class MessageService : BaseService, IMessageService
{
    public MessageService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<List<RankingUpdateMessage>> GetMessages() => 
        await DbContext.MatchResultMessages.Select(m => new RankingUpdateMessage() { Content = m.Content, Date = m.Date }).ToListAsync();
}
