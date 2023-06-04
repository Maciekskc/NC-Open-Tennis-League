using Communication.DTOs.Message;
using Persistance.Models;

namespace Application.Mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial RankingUpdateMessage MatchResultMessageToRankingUpdateMessage(MatchResultMessage message);
        public partial RankingUpdateMessage NewChellangeMessageToRankingUpdateMessage(NewChellangeMessage message);
    }
}
