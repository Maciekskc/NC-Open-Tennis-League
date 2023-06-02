using Infrastructure.DTOs.Ranking;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class RankingService : BaseService, IRankingService
{
    public RankingService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<List<RankingRecord>> GetRanking()
    {
        var positions = await DbContext.Players.Select(p => Mapper.TennisPlayerToRankingRecord(p)).ToListAsync();
        positions.Sort((x, y) => x.Position - y.Position);
        return positions;
    }
}
