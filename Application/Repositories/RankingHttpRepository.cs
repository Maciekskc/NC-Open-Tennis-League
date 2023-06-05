using Application.Repositories.Interfaces;
using Communication.DTOs.Ranking;

namespace Application.Repositories;

public class RankingHttpRepository : BaseHttpRepository, IRankingHttpRepository
{
    public RankingHttpRepository(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<List<RankingRecord>> GetRanking()
    {
        return await GetAsync<List<RankingRecord>> (ApiRoutes.TennisPlayers.GetRanking);
    }
}
