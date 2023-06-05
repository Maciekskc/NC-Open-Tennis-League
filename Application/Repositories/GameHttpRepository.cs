using Application.Interfaces;
using Application.Repositories;
using Communication.DTOs.Games;

namespace Application.Services;

public class GameHttpRepository : BaseHttpRepository, IGameHttpRepository
{
    public GameHttpRepository(HttpClient client) : base(client)
    {
    }

    public async Task<GetGameResponse> CreateAsync(CreateGameRequest gameDto)
    {
        return await PostAsync<CreateGameRequest, GetGameResponse>(ApiRoutes.Games.Create, gameDto);
    }

    public async Task<List<GetGameResponse>> GetAllAsync()
    {
        return await GetAsync<List<GetGameResponse>>(ApiRoutes.Games.GetAll);
    }

    public async Task<GetGameResponse?> GetViewModelByIdAsync(Guid id)
    {
        return await GetAsync<GetGameResponse?>(ApiRouteHelper.ReplaceId(ApiRoutes.Games.GetViewModelById, id.ToString()));
    }

    public async Task<GetGameResponse?> GetByIdAsync(Guid id)
    {
        return await GetAsync<GetGameResponse?>(ApiRouteHelper.ReplaceId(ApiRoutes.Games.GetById, id.ToString()));
    }

    public async Task FinalizeGameAsync(FinalizeGameRequest finalizeGameDto)
    {
        await PostAsync<FinalizeGameRequest>(ApiRoutes.Games.Finalize, finalizeGameDto);
    }

    public Task<List<GetGameResponse>> GetAllPlayerGamesAsync(Guid PlayerId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdateGameRequest gameDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
