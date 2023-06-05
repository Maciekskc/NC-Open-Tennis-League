using Application.Repositories.Interfaces;
using Communication;
using Communication.DTOs.TennisPlayer;

namespace Application.Repositories
{
    public class TennisPlayerHttpRepository : BaseHttpRepository, ITennisPlayerHttpRepository
    {
        public TennisPlayerHttpRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<GetTennisPlayerResponse> CreateAsync(CreateTennisPlayerRequest playerDto)
        {
            return await PostAsync<CreateTennisPlayerRequest, GetTennisPlayerResponse>(ApiRoutes.TennisPlayers.Create, playerDto); 
        }

        public async Task<GetTennisPlayerResponse?> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            var argument = ApiRouteHelper.ReplaceId(ApiRoutes.TennisPlayers.GetById, id);
            return await GetAsync<GetTennisPlayerResponse?>(argument);
        }

        public async Task<List<GetTennisPlayerResponse>> GetAllAsync()
        {
            return await GetAsync<List<GetTennisPlayerResponse>>(ApiRoutes.TennisPlayers.GetAll);
        }

        public async Task UpdateAsync(Guid id, UpdateTennisPlayerRequest playerDto)
        {
            await PutAsync(ApiRouteHelper.ReplaceId(ApiRoutes.TennisPlayers.Update, playerDto.PlayerId.ToString()), playerDto);
        }

        public async Task RemoveAsync(Guid id)
        {
            await DeleteAsync(ApiRouteHelper.ReplaceId(ApiRoutes.TennisPlayers.Delete, id.ToString()));
        }
    }

}
