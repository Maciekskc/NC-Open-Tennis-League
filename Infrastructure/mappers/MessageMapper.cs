using Communication.DTOs.Message;
using Persistance.Models;

namespace Infrastructure.mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial RankingUpdateMessage MatchResultMessageToRankingUpdateMessage(MatchResultMessage message);
        public partial RankingUpdateMessage NewChellangeMessageToRankingUpdateMessage(NewChellangeMessage message);
    }
}
