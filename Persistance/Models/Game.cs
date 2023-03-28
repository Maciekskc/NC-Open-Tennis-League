using System.ComponentModel.DataAnnotations;

namespace Persistance.Models;

public record class Game
{
    public Guid GameId { get; } = Guid.NewGuid();
    
    public Guid ChallengingPlayerId { get; init; }

    public TennisPlayer ChallengingPlayer { get; init; }

    public Guid ChallengedPlayerId { get; init; }
    public TennisPlayer ChallengedPlayer { get; init; }

    public DateTime ChallengeDate  { get; set; } = DateTime.Now;

    public DateTime? MatchDate { get; set; } = null;
    
    /// <summary>
    /// Information if chellenging player won the game
    /// </summary>
    public bool? Win { get; set; } = null;
    
    public bool Walkover { get; set; } = false;

    //Properties for further development
    public int ChallengingPlayerWonGemsCount { get; set; } = 0;
    public int ChallengedPlayerWonGemsCount { get; set; } = 0;
}