using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Communication.DTOs.Games;

namespace API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Base)]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost(ApiRoutes.Games.Create)]
        public async Task<IActionResult> Create(CreateGameRequest gameDto)
        {
            var createdGame = await _gameService.CreateAsync(gameDto);
            return CreatedAtAction(nameof(GetById), new { id = createdGame.GameId }, createdGame);
        }

        [HttpPost(ApiRoutes.Games.Finalize)]
        public async Task<IActionResult> Finalize(FinalizeGameRequest gameDto)
        {
            await _gameService.FinalizeGameAsync(gameDto);
            return NoContent();
        }

        [HttpGet(ApiRoutes.Games.GetById)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
                return NotFound();

            return Ok(game);
        }

        [HttpGet(ApiRoutes.Games.GetViewModelById)]
        public async Task<IActionResult> GetViewModelById(Guid id)
        {
            var gameViewModel = await _gameService.GetViewModelByIdAsync(id);
            if (gameViewModel == null)
                return NotFound();

            return Ok(gameViewModel);
        }

        [HttpGet(ApiRoutes.Games.GetAllPlayerGames)]
        public async Task<IActionResult> GetAllPlayerGames(Guid playerId)
        {
            var playerGames = await _gameService.GetAllPlayerGamesAsync(playerId);
            return Ok(playerGames);
        }

        [HttpGet(ApiRoutes.Games.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            return Ok(games);
        }

        [HttpPut(ApiRoutes.Games.Update)]
        public async Task<IActionResult> Update(Guid id, GetGameResponse gameDto)
        {
            await _gameService.UpdateAsync(id, gameDto);
            return NoContent();
        }

        [HttpDelete(ApiRoutes.Games.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameService.DeleteAsync(id);
            return NoContent();
        }
    }
}