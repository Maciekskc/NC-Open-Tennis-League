using Application.DTOs.Message;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        Task<List<RankingUpdateMessage>> GetMessages();
    }
}
