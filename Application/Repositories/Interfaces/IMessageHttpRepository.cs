using Communication.DTOs.Message;

namespace Application.Interfaces
{
    public interface IMessageHttpRepository
    {
        Task<List<RankingUpdateMessage>> GetMessages();
    }
}
