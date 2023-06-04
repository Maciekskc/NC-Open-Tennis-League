using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Communication.DTOs.TennisPlayer;

namespace API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Base)]
    public class TennisPlayerController : ControllerBase
    {
        private readonly ITennisPlayerService _tennisPlayerService;

        public TennisPlayerController(ITennisPlayerService tennisPlayerService)
        {
            _tennisPlayerService = tennisPlayerService;
        }

        [HttpPost(ApiRoutes.TennisPlayers.Create)]
        public async Task<IActionResult> Create(TennisPlayerDto playerDto)
        {
            var createdPlayer = await _tennisPlayerService.CreateAsync(playerDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
        }

        [HttpGet(ApiRoutes.TennisPlayers.GetById)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var player = await _tennisPlayerService.GetByIdAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpGet(ApiRoutes.TennisPlayers.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var players = await _tennisPlayerService.GetAllAsync();
            return Ok(players);
        }

        [HttpPut(ApiRoutes.TennisPlayers.Update)]
        public async Task<IActionResult> Update(Guid id, TennisPlayerDto playerDto)
        {
            await _tennisPlayerService.UpdateAsync(id, playerDto);
            return NoContent();
        }

        [HttpDelete(ApiRoutes.TennisPlayers.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tennisPlayerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(ApiRoutes.TennisPlayers.GetRanking)]
        public async Task<IActionResult> GetRanking()
        {
            var ranking = await _tennisPlayerService.GetRanking();
            return Ok(ranking);
        }
    }
}