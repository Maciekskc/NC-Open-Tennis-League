namespace Communication.DTOs.Games;

public record GetGameResponse
{
    public Guid GameId { get; set; }

    public string ChallengingPlayerName { get; init; }

    public string ChallengedPlayerName { get; init; }

    public DateTime ChallengeDate { get; set; } = DateTime.Now;

    public DateTime? MatchDate { get; set; } = null;

    /// <summary>
    /// Information if chellenging player won the game
    /// </summary>
    public bool? Win { get; set; } = null;

    public bool? Walkover { get; set; } = false;

    //Properties for further development
    public int ChallengingPlayerWonGemsCount { get; set; } = 0;
    public int ChallengedPlayerWonGemsCount { get; set; } = 0;
}
