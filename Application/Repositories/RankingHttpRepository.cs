using Application.Interfaces;
using Application.Repositories;
using Communication.DTOs.Ranking;

namespace Application.Services;

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
