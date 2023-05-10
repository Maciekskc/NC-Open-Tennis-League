using Application.DTOs.Games;
using Application.DTOs.Ranking;
using Application.DTOs.TennisPlayer;
using Persistance.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial TennisPlayerDto TennisPlayerToTennisPlayerDto(TennisPlayer tennisPlayer);
        public partial TennisPlayer TennisPlayerDtoToTennisPlayer(TennisPlayerDto tennisPlayer);

        [MapProperty(nameof(TennisPlayer.Id),  nameof(RankingRecord.PlayerId))]
        [MapProperty(nameof(TennisPlayer.CurrentPosition),  nameof(RankingRecord.Position))]
        public partial RankingRecord TennisPlayerToRankingRecord(TennisPlayer tennisPlayer);
    }
}
