namespace Data.Models;

public record ServiceMessage
{
    public Guid MessageId { get; } = Guid.NewGuid();

    public string Content { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}