using Application.DTOs.Ranking;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class RankingService : BaseService, IRankingService
{
    public RankingService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<List<RankingRecord>> GetRanking()
    {
        var positions = await DbContext.Players.Select(p => new RankingRecord { Inititials = p.Initials, PlayerId = p.Id, Position = p.CurrentPosition }).ToListAsync();
        positions.Sort((x, y) => x.Position - y.Position);
        return positions;
    }
}
