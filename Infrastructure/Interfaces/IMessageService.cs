using Communication.DTOs.Message;

namespace Infrastructure.Interfaces
{
    public interface IMessageService
    {
        Task<List<RankingUpdateMessage>> GetMessages();
    }
}
