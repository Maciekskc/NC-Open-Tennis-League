using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Models
{
    public class TennisPlayer
    {
        public Guid Id { get; set; }
        public string Initials { get; set; }

        public ICollection<Game> ChallengingGames { get; set; }
        public ICollection<Game> ChallengedGames { get; set; }
        public ICollection<LeaguePositions> Positions { get; set; }
        public int CurrentPosition { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<Game> Games()
        {
            return (ICollection<Game>)ChallengedGames.Concat(ChallengingGames);
        }
    }
}
