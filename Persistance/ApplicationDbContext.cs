using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.Models;

namespace Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    { 
        public DbSet<TennisPlayer> Players { get; set; }
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
            builder.Entity<TennisPlayer>()
                .HasKey(x => x.Id);
            builder.Entity<Game>()
                .HasKey(x => x.GameId);
            builder.Entity<LeaguePositions>()
                .HasKey(x => x.LeaguePositionId);
            builder.Entity<ServiceMessage>()
                .HasKey(x => x.MessageId);

            //Config FK
            builder.Entity<Game>()
                .HasOne(g => g.ChallengedPlayer)
                .WithMany(p => p.ChallengedGames)
                .HasForeignKey(g => g.ChallengedPlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()                
                .HasOne(g => g.ChallengingPlayer)
                .WithMany(p => p.ChallengingGames)
                .HasForeignKey(g => g.ChallengingPlayerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<LeaguePositions>()
                .HasOne(g => g.Player)
                .WithMany(p => p.Positions)
                .HasForeignKey(g => g.PlayerId);

            builder.Entity<MatchResultMessage>()
                .HasOne(g => g.Game)
                .WithMany()
                .HasForeignKey(x => x.GameId);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Player)
                .WithOne(p => p.User)
                .HasForeignKey<TennisPlayer>(p=>p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}