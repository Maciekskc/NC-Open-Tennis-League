using Application.DTOs.Games;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Persistance.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services;

public class GameService : BaseService, IGameService
{
    public GameService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public Task<Game> CreateAsync(CreateGameDto playerDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<GameViewDto>> GetAllAsync() =>
        await DbContext.Games.Select(g => new GameViewDto
        { 
            ChallengedPlayerName= g.ChallengedPlayer.Initials,
            ChallengingPlayerName= g.ChallengingPlayer.Initials,
            MatchDate=g.MatchDate
        }).ToListAsync();

    public Task<GameViewDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, GameViewDto gameDto)
    {
        throw new NotImplementedException();
    }

    Task<List<GameViewDto>> IGameService.GetAllPlayerGamesAsync(Guid PlayerId)
    {
        throw new NotImplementedException();
    }
}
