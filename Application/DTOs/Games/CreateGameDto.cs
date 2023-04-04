using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Games;

public record CreateGameDto
{
    public Guid ChallengingPlayerId { get; set; }

    public Guid ChallengedPlayerId { get; set; }

    public DateTime ChallengeDate { get; set; } = DateTime.Now;

    public DateTime? MatchDate { get; set; } = null;
}
