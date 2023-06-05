namespace Communication.DTOs.Ranking;

public class RankingRecordResponse
{
    public Guid PlayerId { get; set; }
    public string Initials { get; set; }
    public int Position { get; set; }
}
