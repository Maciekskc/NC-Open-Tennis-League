using Communication.DTOs.Games;

namespace Application.Repositories.Interfaces;

public interface IGameHttpRepository
{
    Task<GetGameResponse> CreateAsync(CreateGameRequest gameDto); 
    Task FinalizeGameAsync(FinalizeGameRequest gameDto);
    Task<GetGameResponse?> GetByIdAsync(Guid id);
    Task<GetGameResponse?> GetViewModelByIdAsync(Guid id);
    Task<List<GetGameResponse>> GetAllPlayerGamesAsync(Guid PlayerId);
    Task<List<GetGameResponse>> GetAllAsync();
    Task UpdateAsync(Guid id, UpdateGameRequest gameDto);
    Task DeleteAsync(Guid id);
}
