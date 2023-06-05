using Application.Repositories.Interfaces;
using Communication;
using Communication.DTOs.Games;
using Persistance.Models;

namespace Application.Repositories;

public class GameHttpRepository : BaseHttpRepository, IGameHttpRepository
{
    public GameHttpRepository(HttpClient client) : base(client)
    {
    }

    public async Task<Game> CreateAsync(CreateGameDto gameDto)
    {
        return await PostAsync<CreateGameDto,Game>(ApiRoutes.Games.Create, gameDto);
    }

    public async Task<List<GameViewDto>> GetAllAsync()
    {
        return await GetAsync<List<GameViewDto>>(ApiRoutes.Games.GetAll);
    }

    public async Task<GameViewDto?> GetViewModelByIdAsync(Guid id)
    {
        return await GetAsync<GameViewDto?>(ApiRouteHelper.ReplaceId(ApiRoutes.Games.GetViewModelById, id.ToString()));
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await GetAsync<Game?>(ApiRouteHelper.ReplaceId(ApiRoutes.Games.GetById, id.ToString()));
    }

    public async Task FinalizeGameAsync(FinalizeGameDto finalizeGameDto)
    {
        await PostAsync<FinalizeGameDto>(ApiRoutes.Games.Finalize, finalizeGameDto);
    }

    public Task<List<GameViewDto>> GetAllPlayerGamesAsync(Guid PlayerId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, GameViewDto gameDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
