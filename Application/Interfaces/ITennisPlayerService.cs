using Application.DTOs.TennisPlayer;
using Persistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITennisPlayerService
    {
        Task<TennisPlayer> CreateAsync(TennisPlayerDto playerDto);
        Task<TennisPlayer> GetByIdAsync(Guid id);
        Task<IEnumerable<TennisPlayer>> GetAllAsync();
        Task UpdateAsync(Guid id, TennisPlayerDto playerDto);
        Task DeleteAsync(Guid id);
    }
}
