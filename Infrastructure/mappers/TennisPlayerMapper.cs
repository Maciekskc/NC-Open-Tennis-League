using Infrastructure.DTOs.Ranking;
using Infrastructure.DTOs.TennisPlayer;

namespace Infrastructure.mappers
{
    public partial class CustomMaperlyMapper
    {
        [MapProperty(nameof(TennisPlayer.Id), nameof(TennisPlayerDto.PlayerId))]
        [MapProperty(nameof(TennisPlayer.CurrentPosition), nameof(TennisPlayerDto.Position))]
        public partial TennisPlayerDto TennisPlayerToTennisPlayerDto(TennisPlayer tennisPlayer);

        
        [MapProperty(nameof(TennisPlayerDto.PlayerId), nameof(TennisPlayer.Id))]
        [MapProperty(nameof(TennisPlayerDto.Position), nameof(TennisPlayer.CurrentPosition))]
        public partial TennisPlayer TennisPlayerDtoToTennisPlayer(TennisPlayerDto tennisPlayer);

        [MapProperty(nameof(TennisPlayer.Id),  nameof(RankingRecord.PlayerId))]
        [MapProperty(nameof(TennisPlayer.CurrentPosition),  nameof(RankingRecord.Position))]
        public partial RankingRecord TennisPlayerToRankingRecord(TennisPlayer tennisPlayer);
    }
}
