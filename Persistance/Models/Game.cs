using System.ComponentModel.DataAnnotations;

namespace Persistance.Models;

public record class Game
{
    public Guid GameId { get; } = Guid.NewGuid();
    
    public string ChellengingPlayerId { get; init; }

    public ApplicationUser ChellengingPlayer { get; init; }

    public string ChellangedPlayerId { get; init; }
    public ApplicationUser ChellangedPlayer { get; init; }

    public DateTime ChallengeDate  { get; set; } = DateTime.Now;

    public DateTime? MatchDate { get; set; } = null;
    
    /// <summary>
    /// Information if chellenging player won the game
    /// </summary>
    public bool? Win { get; set; } = null;
    
    public bool Walkover { get; set; } = false;

    //Properties for further development
    public int ChellangingPlayerWonGemsCount { get; set; } = 0;
    public int ChellangedPlayerWonGemsCount { get; set; } = 0;
}