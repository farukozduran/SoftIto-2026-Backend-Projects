using Microsoft.EntityFrameworkCore;
using Project.World.Cup.Model;

namespace Project.World.Cup.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupTeam> GroupTeams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Tournament)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Group)
                .WithMany(g => g.Matches)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Stadium)
                .WithMany(s => s.Matches)
                .HasForeignKey(m => m.StadiumId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<GroupTeam>()
                .HasOne(gt => gt.Group)
                .WithMany(g => g.GroupTeams)
                .HasForeignKey(gt => gt.GroupId);

            modelBuilder.Entity<GroupTeam>()
                .HasOne(gt => gt.Team)
                .WithMany(t => t.GroupTeams)
                .HasForeignKey(gt => gt.TeamId);

            modelBuilder.Entity<MatchEvent>()
                .HasOne(me => me.Match)
                .WithMany(m => m.MatchEvents)
                .HasForeignKey(me => me.MatchId);

            modelBuilder.Entity<MatchEvent>()
                .HasOne(me => me.Team)
                .WithMany(t => t.MatchEvents)
                .HasForeignKey(me => me.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
