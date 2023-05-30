namespace Persistance.Models;

public record class NewChellangeMessage : ServiceMessage
{
    public Guid GameId { get; set; }
    public Game Game { get; set; }
}