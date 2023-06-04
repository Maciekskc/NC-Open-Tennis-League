namespace Communication.DTOs.TennisPlayer;

public record TennisPlayerDto
{
    public Guid PlayerId { get; set; }
    public string Initials { get; set; }
    public int Position { get; set; }
}
