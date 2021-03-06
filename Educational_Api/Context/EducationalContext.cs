using Educational_Api.Models.Enums;
using Educational_Api.Models.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Educational_Api.Models.Context
{
	public class EducationalContext : DbContext
	{
		public EducationalContext(DbContextOptions<EducationalContext> options)
			: base(options)
		{
		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Class> Classes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().ToTable("student");
			modelBuilder.Entity<Class>().ToTable("class");

			modelBuilder.Entity<Student>()
				.HasOne(e => e.Class)
				.WithMany(c => c.Students);

			modelBuilder.Entity<Student>()
				.Property(p => p.Genre)
				.HasConversion(typeof(string));
		}
	}
}
