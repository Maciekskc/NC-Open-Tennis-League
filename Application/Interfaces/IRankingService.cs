using Application.DTOs.Ranking;

namespace Application.Interfaces;

public interface IRankingService
{
    Task<List<RankingRecord>> GetRanking();
}
