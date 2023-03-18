using Application.DTOs.Games;
using Application.Interfaces;
using Infrastructure.Services;
using Persistance.Models;

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

    public Task<IEnumerable<GameViewDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GameViewDto>> GetAllPlayerGamesAsync(Guid PlayerId)
    {
        throw new NotImplementedException();
    }

    public Task<GameViewDto?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, GameViewDto gameDto)
    {
        throw new NotImplementedException();
    }
}
