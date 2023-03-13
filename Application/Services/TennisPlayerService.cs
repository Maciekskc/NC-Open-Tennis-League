﻿using Application.DTOs.TennisPlayer;
using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Persistance.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TennisPlayerService : BaseService, ITennisPlayerService
    {
        public TennisPlayerService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<TennisPlayer> CreateAsync(TennisPlayerDto playerDto)
        {
            var player = new TennisPlayer
            {
                Id = Guid.NewGuid(),
                Initials = playerDto.Initials,
                ChellengingGames = new List<Game>(),
                ChellangedGames = new List<Game>(),
                Positions = new List<LeaguePositions>(),
                CurrentPosition = DbContext.Players.Select(p=>p.CurrentPosition).ToArray().Max() + 1,
            };

            await DbContext.Players.AddAsync(player);
            await DbContext.SaveChangesAsync();

            return player;
        }

        public async Task<TennisPlayerDto?> GetByIdAsync(Guid id) { 
            var player =  await DbContext.Players.FindAsync(id);
            if (player != null)
                return new TennisPlayerDto
                {
                    PlayerId = player.Id,
                    Initials = player.Initials,
                    Position = player.CurrentPosition
                };
            return null;
        }

        public async Task<IEnumerable<TennisPlayer>> GetAllAsync() => await DbContext.Players.ToListAsync();

        public async Task UpdateAsync(Guid id, TennisPlayerDto playerDto)
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

            DbContext.Players.Remove(player);
            await DbContext.SaveChangesAsync();
        }
    }

}
