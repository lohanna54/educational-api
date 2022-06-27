using Microsoft.EntityFrameworkCore;

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
			modelBuilder.Entity<Class>().ToTable("classs");
		}
	}
}
