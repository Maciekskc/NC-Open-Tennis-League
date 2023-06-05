using Application.Repositories.Interfaces;
using Communication;
using Communication.DTOs.TennisPlayer;
using Persistance.Models;

namespace Application.Repositories
{
    public class TennisPlayerHttpRepository : BaseHttpRepository, ITennisPlayerHttpRepository
    {
        public TennisPlayerHttpRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<TennisPlayer> CreateAsync(TennisPlayerDto playerDto)
        {
            return await PostAsync<TennisPlayerDto,TennisPlayer>(ApiRoutes.TennisPlayers.Create, playerDto); 
        }

        public async Task<TennisPlayerDto?> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            var argument = ApiRouteHelper.ReplaceId(ApiRoutes.TennisPlayers.GetById, id);
            return await GetAsync<TennisPlayerDto?>(argument);
        }

        public async Task<List<TennisPlayerDto>> GetAllAsync()
        {
            return await GetAsync<List<TennisPlayerDto>>(ApiRoutes.TennisPlayers.GetAll);
        }

        public async Task UpdateAsync(Guid id, TennisPlayerDto playerDto)
        {
            await PutAsync(ApiRouteHelper.ReplaceId(ApiRoutes.TennisPlayers.Update, playerDto.PlayerId.ToString()), playerDto);
        }

        public async Task RemoveAsync(Guid id)
        {
            await DeleteAsync(ApiRouteHelper.ReplaceId(ApiRoutes.TennisPlayers.Delete, id.ToString()));
        }
    }

}
