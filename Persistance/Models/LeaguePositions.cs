namespace Persistance.Models;

public record class LeaguePositions
{
    public Guid LeaguePositionId { get; } = Guid.NewGuid();

    public Guid PlayerId { get; set; }
    public TennisPlayer Player { get; set; }

    public int Position { get; set; }

    public DateTime DateFrom { get; set; } = DateTime.Now;
    public DateTime? DateTo { get; set; } = null;
}