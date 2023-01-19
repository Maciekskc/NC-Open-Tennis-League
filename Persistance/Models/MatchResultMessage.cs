namespace Persistance.Models;

public record class MatchResultMessage : ServiceMessage
{
    public Guid GameId { get; set; }
    public Game Game { get; set; }
    
    public List<LeaguePositions> RelatedPositionUpdates { get; set; }
}