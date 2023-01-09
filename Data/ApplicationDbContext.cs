using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace RPGApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<ManualTab> Tabs { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserSession>()
                .HasKey(x => new { x.SessionIdsFK, x.UserIdsFK });

            builder.Entity<UserSession>()
               .HasOne(x => x.User)
               .WithMany(x => x.Sessions)
               .HasForeignKey(x => x.UserIdsFK);

            builder.Entity<UserSession>()
                  .HasOne(x => x.Session)
                  .WithMany(x => x.Users)
                  .HasForeignKey(x => x.SessionIdsFK);

            builder.Entity<Session>()
                .HasMany(x => x.Notes)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId);
            builder.Entity<Session>()
                .HasMany(x => x.Cards)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId);
            builder.Entity<Session>()
                .HasMany(x => x.Maps)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId);
            builder.Entity<Session>()
                .HasMany(x => x.Tabs)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "GameMaster", NormalizedName = "GameMaster".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Player", NormalizedName = "Player".ToUpper() });
        }
    }
}