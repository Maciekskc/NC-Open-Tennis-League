using Application.DTOs.Games;
using Persistance.Models;

namespace Application.Interfaces;

public interface IGameService
{
    Task<Game> CreateAsync(CreateGameDto playerDto);
    Task<GameViewDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<GameViewDto>> GetAllPlayerGamesAsync(Guid PlayerId);
    Task<IEnumerable<GameViewDto>> GetAllAsync();
    Task UpdateAsync(Guid id, GameViewDto gameDto);
    Task DeleteAsync(Guid id);
}
