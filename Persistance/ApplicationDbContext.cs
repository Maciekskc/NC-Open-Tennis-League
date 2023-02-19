using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<LeaguePositions> GeneralClassification { get; set; }
        public DbSet<ServiceMessage> ServiceMessages { get; set; }
        public DbSet<MatchResultMessage> MatchResultMessages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
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
                .HasForeignKey(g => g.ChellangedPlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()
                .HasOne(g => g.ChellengingPlayer)
                .WithMany(p => p.ChellengingGames)
                .HasForeignKey(g => g.ChellengingPlayerId)
                .OnDelete(DeleteBehavior.NoAction);

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
}