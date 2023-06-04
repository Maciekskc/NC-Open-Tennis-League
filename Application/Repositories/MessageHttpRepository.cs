using Application.Interfaces;
using Application.Repositories;
using Communication.DTOs.Message;
namespace Application.Services;

public class MessageHttpRepository : BaseHttpRepository, IMessageHttpRepository
{
    public MessageHttpRepository(HttpClient client) : base(client)
    {
    }

    public async Task<List<RankingUpdateMessage>> GetMessages() => await GetAsync<List<RankingUpdateMessage>>(ApiRoutes.Messages.GetMessages);
}
