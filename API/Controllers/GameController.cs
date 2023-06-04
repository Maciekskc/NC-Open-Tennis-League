using Infrastructure.DTOs.Games;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGameDto gameDto)
        {
            var createdGame = await _gameService.CreateAsync(gameDto);
            return CreatedAtAction(nameof(GetById), new { id = createdGame.GameId }, createdGame);
        }

        [HttpPost("finalize")]
        public async Task<IActionResult> Finalize(FinalizeGameDto gameDto)
        {
            await _gameService.FinalizeGameAsync(gameDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
                return NotFound();

            return Ok(game);
        }

        [HttpGet("viewmodel/{id}")]
        public async Task<IActionResult> GetViewModelById(Guid id)
        {
            var gameViewModel = await _gameService.GetViewModelByIdAsync(id);
            if (gameViewModel == null)
                return NotFound();

            return Ok(gameViewModel);
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetAllPlayerGames(Guid playerId)
        {
            var playerGames = await _gameService.GetAllPlayerGamesAsync(playerId);
            return Ok(playerGames);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            return Ok(games);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, GameViewDto gameDto)
        {
            await _gameService.UpdateAsync(id, gameDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameService.DeleteAsync(id);
            return NoContent();
        }
    }
}
