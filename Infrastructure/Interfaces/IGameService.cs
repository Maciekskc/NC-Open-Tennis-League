using Communication.DTOs.Games;
using Persistance.Models;

namespace Infrastructure.Interfaces;

public interface IGameService
{
    Task<GetGameResponse> CreateAsync(CreateGameRequest gameDto); 
    Task FinalizeGameAsync(FinalizeGameRequest gameDto);
    Task<Game?> GetByIdAsync(Guid id);
    Task<GetGameResponse?> GetViewModelByIdAsync(Guid id);
    Task<List<GetGameResponse>> GetAllPlayerGamesAsync(Guid PlayerId);
    Task<List<GetGameResponse>> GetAllAsync();
    Task UpdateAsync(Guid id, UpdateGameRequest gameDto);
    Task DeleteAsync(Guid id);
}
