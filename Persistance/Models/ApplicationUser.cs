using Microsoft.AspNetCore.Identity;

namespace Persistance.Models;

public class ApplicationUser : IdentityUser
{
    public string Initials { get; set; }
    
    public ICollection<Game> ChellengingGames { get; set; }
    public ICollection<Game> ChellangedGames { get; set; }
    public ICollection<LeaguePositions> Positions { get; set; }
    public int CurrentPosition { get; set; }

    public ICollection<Game> Games()
    {
        return (ICollection<Game>)ChellangedGames.Concat(ChellengingGames);
    }
}
