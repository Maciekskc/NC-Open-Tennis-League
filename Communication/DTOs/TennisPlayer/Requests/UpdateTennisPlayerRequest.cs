namespace Communication.DTOs.TennisPlayer;

public record UpdateTennisPlayerRequest
{
    public Guid PlayerId { get; set; }

    public string Initials { get; set; }
}
