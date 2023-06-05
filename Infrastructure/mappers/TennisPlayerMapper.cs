using Communication.DTOs.Ranking;
using Communication.DTOs.TennisPlayer;
using Persistance.Models;
using Riok.Mapperly.Abstractions;

namespace Infrastructure.mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial TennisPlayer CreateTennisPlayerRequestToTennisPlayer(CreateTennisPlayerRequest tennisPlayer);


        [MapProperty(nameof(UpdateTennisPlayerRequest.PlayerId), nameof(TennisPlayer.Id))]
        public partial TennisPlayer UptadeTennisPlayerRequestToTennisPlayer(UpdateTennisPlayerRequest tennisPlayer);

        [MapProperty(nameof(TennisPlayer.Id), nameof(GetTennisPlayerResponse.PlayerId))]
        [MapProperty(nameof(TennisPlayer.CurrentPosition), nameof(GetTennisPlayerResponse.Position))]
        public partial GetTennisPlayerResponse TennisPlayerToGetTennisPlayerResponse(TennisPlayer tennisPlayer);

        [MapProperty(nameof(TennisPlayer.Id),  nameof(RankingRecordResponse.PlayerId))]
        [MapProperty(nameof(TennisPlayer.CurrentPosition),  nameof(RankingRecordResponse.Position))]
        public partial RankingRecordResponse TennisPlayerToRankingRecord(TennisPlayer tennisPlayer);
    }
}
