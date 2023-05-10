using Application.DTOs.TennisPlayer;
using Persistance.Models;

namespace Application.Mappers
{
    public partial class CustomMaperlyMapper
    {
        public partial TennisPlayerDto TennisPlayerToTennisPlayerDto(TennisPlayer tennisPlayer); 
        public partial TennisPlayer TennisPlayerDtoToTennisPlayer(TennisPlayerDto tennisPlayer);
    }
}
