using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Games;

public record GameViewDto
{

    public Guid GameId { get; } = Guid.NewGuid();

    public Guid ChellengingPlayerId { get; init; }

    public Guid ChellangedPlayerId { get; init; }

    public DateTime ChallengeDate { get; set; } = DateTime.Now;

    public DateTime? MatchDate { get; set; } = null;

    /// <summary>
    /// Information if chellenging player won the game
    /// </summary>
    public bool? Win { get; set; } = null;

    public bool? Walkover { get; set; } = false;

    //Properties for further development
    public int ChellangingPlayerWonGemsCount { get; set; } = 0;
    public int ChellangedPlayerWonGemsCount { get; set; } = 0;
}
