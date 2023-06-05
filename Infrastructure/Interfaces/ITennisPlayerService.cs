using Communication.DTOs.Ranking;
using Communication.DTOs.TennisPlayer;
using Persistance.Models;

namespace Infrastructure.Interfaces
{
    public interface ITennisPlayerService
    {
        Task<GetTennisPlayerResponse> CreateAsync(CreateTennisPlayerRequest playerDto);
        Task<GetTennisPlayerResponse?> GetByIdAsync(Guid id);
        Task<List<GetTennisPlayerResponse>> GetAllAsync();
        Task UpdateAsync(Guid id, UpdateTennisPlayerRequest playerDto);
        Task DeleteAsync(Guid id);
        Task<List<RankingRecordResponse>> GetRanking();
    }
}
