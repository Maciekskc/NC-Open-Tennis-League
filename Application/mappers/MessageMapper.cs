using Application.DTOs.Games;
using Application.DTOs.Message;
using Persistance.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial RankingUpdateMessage MatchResultMessageToRankingUpdateMessage(MatchResultMessage message);
        public partial RankingUpdateMessage NewChellangeMessageToRankingUpdateMessage(NewChellangeMessage message);
    }
}
