using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Session>()
				.HasMany(x => x.Notes)
				.WithOne(x => x.Session)
				.HasForeignKey(x => x.SessionId);
			builder.Entity<User>()
				.HasMany(x => x.Sessions)
				.WithOne(x => x.GameMaster)
				.HasForeignKey(x => x.GameMasterId);
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