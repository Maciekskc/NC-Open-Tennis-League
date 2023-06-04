using Infrastructure.DTOs.TennisPlayer;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/tennisplayers")]
    public class TennisPlayerController : ControllerBase
    {
        private readonly ITennisPlayerService _tennisPlayerService;

        public TennisPlayerController(ITennisPlayerService tennisPlayerService)
        {
            _tennisPlayerService = tennisPlayerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TennisPlayerDto playerDto)
        {
            var createdPlayer = await _tennisPlayerService.CreateAsync(playerDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var player = await _tennisPlayerService.GetByIdAsync(id);
            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _tennisPlayerService.GetAllAsync();
            return Ok(players);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TennisPlayerDto playerDto)
        {
            await _tennisPlayerService.UpdateAsync(id, playerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tennisPlayerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("ranking")]
        public async Task<IActionResult> GetRanking()
        {
            var ranking = await _tennisPlayerService.GetRanking();
            return Ok(ranking);
        }
    }
}
