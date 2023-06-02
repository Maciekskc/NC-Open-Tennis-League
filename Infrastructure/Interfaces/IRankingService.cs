using Infrastructure.DTOs.Ranking;

namespace Infrastructure.Interfaces;

public interface IRankingService
{
    Task<List<RankingRecord>> GetRanking();
}
