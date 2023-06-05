using Communication.DTOs.TennisPlayer;
using Persistance.Models;

namespace Application.Interfaces
{
    public interface ITennisPlayerHttpRepository
    {
        Task<GetTennisPlayerResponse> CreateAsync(CreateTennisPlayerRequest playerDto);
        Task<GetTennisPlayerResponse?> GetByIdAsync(string id);
        Task<List<GetTennisPlayerResponse>> GetAllAsync();
        Task UpdateAsync(Guid id, UpdateTennisPlayerRequest playerDto);
        Task RemoveAsync(Guid id);
    }
}
