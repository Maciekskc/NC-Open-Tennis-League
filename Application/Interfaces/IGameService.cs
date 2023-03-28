using Application.DTOs.Games;
using Persistance.Models;

namespace Application.Interfaces;

public interface IGameService
{
    Task<Game> CreateAsync(CreateGameDto playerDto);
    Task<GameViewDto?> GetByIdAsync(Guid id);
    Task<List<GameViewDto>> GetAllPlayerGamesAsync(Guid PlayerId);
    Task<List<GameViewDto>> GetAllAsync();
    Task UpdateAsync(Guid id, GameViewDto gameDto);
    Task DeleteAsync(Guid id);
}
