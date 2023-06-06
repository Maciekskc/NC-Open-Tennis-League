using System.ComponentModel.DataAnnotations;

namespace Communication.DTOs.Games
{
    public class FinalizeGameRequest
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
