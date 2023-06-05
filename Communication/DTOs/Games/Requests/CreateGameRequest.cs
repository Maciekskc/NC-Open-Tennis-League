﻿namespace Communication.DTOs.Games;

public record CreateGameRequest
{
    public Guid ChallengingPlayerId { get; set; }

    public Guid ChallengedPlayerId { get; set; }

    public DateTime ChallengeDate { get; set; } = DateTime.Now;

    public DateTime? MatchDate { get; set; } = null;
}
