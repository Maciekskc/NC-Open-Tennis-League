using Communication.DTOs.Ranking;
using Communication.DTOs.TennisPlayer;

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

        Task DeactivatePlayerAsync(Guid id);
        Task ActivatePlayerAsync(Guid id);

    }
}
