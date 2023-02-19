namespace Data.Models;

public record class LeaguePositions
{
    public Guid LeaguePositionId { get; } = Guid.NewGuid();

    public string PlayerId { get; set; }
    public ApplicationUser Player { get; set; }

    public int Position { get; set; }

    public DateTime DateFrom { get; set; } = DateTime.Now;
    public DateTime? DateTo { get; set; } = null;
}