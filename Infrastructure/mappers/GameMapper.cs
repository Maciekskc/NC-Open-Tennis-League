using Communication.DTOs.Games;
using Persistance.Models;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial Game CreateGameRequestToGame(CreateGameRequest createGameDto);
        public partial Game UpdateGameRequestToGame(UpdateGameRequest createGameDto);

        public partial Game FinalizeGameRequestToGame(FinalizeGameRequest gameDto);

        [MapProperty(new[] { nameof(Game.ChallengedPlayer), nameof(Game.ChallengedPlayer.Initials) }, new[] { nameof(GetGameResponse.ChallengedPlayerName) })]
        [MapProperty(new[] { nameof(Game.ChallengingPlayer), nameof(Game.ChallengingPlayer.Initials) } , new[] { nameof(GetGameResponse.ChallengingPlayerName) })]
        public partial GetGameResponse GameToGetGameResponse(Game game);
    }
}
