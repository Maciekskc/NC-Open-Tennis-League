using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistance.Models;

namespace Persistance;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public DbSet<Game> Games { get; set; }
    public DbSet<LeaguePositions> GeneralClassification { get; set; }
    public DbSet<ServiceMessage> ServiceMessages { get; set; }
    public DbSet<MatchResultMessage> MatchResultMessages { get; set; }

    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        //Config PK
        builder.Entity<ApplicationUser>()
            .HasKey(x => x.Id);
        builder.Entity<Game>()
            .HasKey(x => x.GameId);
        builder.Entity<LeaguePositions>()
            .HasKey(x => x.LeaguePositionId);
        builder.Entity<ServiceMessage>()
            .HasKey(x => x.MessageId);
        
        //Config FK
        builder.Entity<Game>()
            .HasOne(g => g.ChellangedPlayer)
            .WithMany(p => p.ChellangedGames)
            .HasForeignKey(g => g.ChellangedPlayerId);

        builder.Entity<Game>()
            .HasOne(g => g.ChellengingPlayer)
            .WithMany(p => p.ChellengingGames)
            .HasForeignKey(g => g.ChellengingPlayerId);
        
        builder.Entity<LeaguePositions>()
            .HasOne(g => g.Player)
            .WithMany(p => p.Positions)
            .HasForeignKey(g => g.PlayerId);

        builder.Entity<MatchResultMessage>()
            .HasOne(g => g.Game)
            .WithMany()
            .HasForeignKey(x => x.GameId);
    }
}