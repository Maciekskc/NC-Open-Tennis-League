using Communication.DTOs.Ranking;

namespace Application.Interfaces;

public interface IRankingHttpRepository
{
    Task<List<RankingRecordResponse>> GetRanking();
}
