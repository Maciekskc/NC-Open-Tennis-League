using Communication.DTOs.TennisPlayer;
using Persistance.Models;

namespace Application.Repositories.Interfaces
{
    public interface ITennisPlayerHttpRepository
    {
        Task<TennisPlayer> CreateAsync(TennisPlayerDto playerDto);
        Task<TennisPlayerDto?> GetByIdAsync(string id);
        Task<List<TennisPlayerDto>> GetAllAsync();
        Task UpdateAsync(Guid id, TennisPlayerDto playerDto);
        Task RemoveAsync(Guid id);
    }
}
