using Communication.DTOs.Games;
using Persistance.Models;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial Game CreateGameDtoToGame(CreateGameDto createGameDto);

        public partial Game FinalizeGameDtoToGame(FinalizeGameDto gameDto);

        [MapProperty(new[] { nameof(Game.ChallengedPlayer), nameof(Game.ChallengedPlayer.Initials) }, new[] { nameof(GameViewDto.ChallengedPlayerName) })]
        [MapProperty(new[] { nameof(Game.ChallengingPlayer), nameof(Game.ChallengingPlayer.Initials) } , new[] { nameof(GameViewDto.ChallengingPlayerName) })]
        public partial GameViewDto GameToGameViewGameDto(Game game);
    }
}
