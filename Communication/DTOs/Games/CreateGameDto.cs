namespace Infrastructure.DTOs.Games;

public record CreateGameDto
{
    public Guid ChallengingPlayerId { get; set; }

    public Guid ChallengedPlayerId { get; set; }

    public DateTime ChallengeDate { get; set; } = DateTime.Now;

    public DateTime? MatchDate { get; set; } = null;
}
