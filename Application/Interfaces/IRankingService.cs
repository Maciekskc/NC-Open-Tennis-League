using Communication.DTOs.Ranking;

namespace Application.Interfaces;

public interface IRankingService
{
    Task<List<RankingRecord>> GetRanking();
}
