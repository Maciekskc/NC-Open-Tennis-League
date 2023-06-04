using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs.Games
{
    public class FinalizeGameDto
    {
        [Required]
        public Guid GameId { get; set; }

        public DateTime MatchDate { get; set; } = DateTime.Now;

        public bool? Win { get; set; }

        public bool Walkover { get; set; }

        public int ChallengingPlayerWonGemsCount { get; set; }

        public int ChallengedPlayerWonGemsCount { get; set; }
    }
}
