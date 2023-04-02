namespace Persistance.Models;

public record class MatchResultMessage : NewChellangeMessage
{
    public List<LeaguePositions> RelatedPositionUpdates { get; set; }
}