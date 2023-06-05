using Communication.DTOs.Ranking;

namespace Application.Repositories.Interfaces;

public interface IRankingHttpRepository
{
    Task<List<RankingRecord>> GetRanking();
}
