using Communication.DTOs.Message;

namespace Application.Repositories.Interfaces
{
    public interface IMessageHttpRepository
    {
        Task<List<RankingUpdateMessage>> GetMessages();
    }
}
