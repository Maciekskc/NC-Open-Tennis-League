using Application.Repositories.Interfaces;
using Communication;
using Communication.DTOs.Ranking;

namespace Application.Repositories;

public class RankingHttpRepository : BaseHttpRepository, IRankingHttpRepository
{
    public RankingHttpRepository(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<RankingRecordResponse>> GetRanking()
    {
        return await GetAsync<List<RankingRecordResponse>> (ApiRoutes.TennisPlayers.GetRanking);
    }
}
