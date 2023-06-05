using Application.Repositories.Interfaces;
using Communication.DTOs.Message;

namespace Application.Repositories;

public class MessageHttpRepository : BaseHttpRepository, IMessageHttpRepository
{
    public MessageHttpRepository(HttpClient client) : base(client)
    {
    }

    public async Task<List<RankingUpdateMessage>> GetMessages() => await GetAsync<List<RankingUpdateMessage>>(ApiRoutes.Messages.GetMessages);
}
