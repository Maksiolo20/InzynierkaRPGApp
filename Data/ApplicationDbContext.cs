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
		//public DbSet<HeroCard> HeroCards { get; set; }
		//public DbSet<BestiaryCard> BestiaryCards { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<Note> Notes { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			//builder.Entity<Session>()
			//	.HasMany(x => x.HeroCards)
			//	.WithOne(x => x.Session)
			//	.HasForeignKey(x => x.SessionId);
			//builder.Entity<Session>()
			//	.HasMany(x => x.BestiaryCards)
			//	.WithOne(x => x.Session)
			//	.HasForeignKey(x => x.SessionId);
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
		}
	}
}