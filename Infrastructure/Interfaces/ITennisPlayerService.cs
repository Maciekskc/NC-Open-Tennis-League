using Infrastructure.DTOs.TennisPlayer;

namespace Infrastructure.Interfaces
{
    public interface ITennisPlayerService
    {
        Task<TennisPlayer> CreateAsync(TennisPlayerDto playerDto);
        Task<TennisPlayerDto?> GetByIdAsync(Guid id);
        Task<List<TennisPlayerDto>> GetAllAsync();
        Task UpdateAsync(Guid id, TennisPlayerDto playerDto);
        Task DeleteAsync(Guid id);
    }
}
