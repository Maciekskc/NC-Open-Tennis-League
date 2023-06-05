using Communication.DTOs.TennisPlayer;

namespace Application.Mappers
{
    public partial class FormMapperlyMapper
    {
        public partial CreateTennisPlayerRequest GetTennisPlayerResponseToCreateTennisPlayerRequest(GetTennisPlayerResponse tennisPlayerResponse);
        public partial UpdateTennisPlayerRequest GetTennisPlayerResponseToUpdateTennisPlayerRequest(GetTennisPlayerResponse tennisPlayerResponse);
    }
}
