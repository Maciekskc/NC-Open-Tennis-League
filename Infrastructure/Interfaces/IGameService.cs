using Communication.DTOs.Games;
using Persistance.Models;

namespace Infrastructure.Interfaces;

public interface IGameService
{
    Task<Game> CreateAsync(CreateGameDto gameDto); 
    Task FinalizeGameAsync(FinalizeGameDto gameDto);
    Task<Game?> GetByIdAsync(Guid id);
    Task<GameViewDto?> GetViewModelByIdAsync(Guid id);
    Task<List<GameViewDto>> GetAllPlayerGamesAsync(Guid PlayerId);
    Task<List<GameViewDto>> GetAllAsync();
    Task UpdateAsync(Guid id, GameViewDto gameDto);
    Task DeleteAsync(Guid id);
}
