using Communication.DTOs.Ranking;
using Communication.DTOs.TennisPlayer;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Models;

namespace Infrastructure.Services
{
    public class TennisPlayerService : BaseService, ITennisPlayerService
    {
        public TennisPlayerService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<GetTennisPlayerResponse> CreateAsync(CreateTennisPlayerRequest playerDto)
        {
            var player = Mapper.CreateTennisPlayerRequestToTennisPlayer(playerDto);

            player.Id = Guid.NewGuid();
            player.CurrentPosition = DbContext.Players.Select(p => p.CurrentPosition).ToArray().Max() + 1;

            await DbContext.Players.AddAsync(player);
            await DbContext.SaveChangesAsync();

            return Mapper.TennisPlayerToGetTennisPlayerResponse(player);
        }

        public async Task<GetTennisPlayerResponse?> GetByIdAsync(Guid id) { 
            var player =  await DbContext.Players.FindAsync(id);
            if (player != null)
                return Mapper.TennisPlayerToGetTennisPlayerResponse(player);
            return null;
        }

        public async Task<List<GetTennisPlayerResponse>> GetAllAsync() => await DbContext.Players.Select(p => Mapper.TennisPlayerToGetTennisPlayerResponse(p)).ToListAsync();

        public async Task UpdateAsync(Guid id, UpdateTennisPlayerRequest playerDto)
        {
            var player = await DbContext.Players.FindAsync(id);

            if (player == null)
            {
                throw new ArgumentException("Player not found");
            }

            player.Initials = playerDto.Initials;

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var player = await DbContext.Players.FindAsync(id);

            if (player == null)
            {
                throw new ArgumentException("Player not found");
            }

            // TODO: Soft delete 
            DbContext.Players.Remove(player);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<RankingRecordResponse>> GetRanking()
        {
            var positions = await DbContext.Players.Select(p => Mapper.TennisPlayerToRankingRecord(p)).ToListAsync();
            positions.Sort((x, y) => x.Position - y.Position);
            return positions;
        }
    }

}
