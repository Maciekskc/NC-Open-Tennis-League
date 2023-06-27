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

        public bool IsActive { get; set; } = true;

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<Game> Games()
        {
            return (ICollection<Game>)ChallengedGames.Concat(ChallengingGames);
        }
    }
}
