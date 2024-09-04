using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models
{
	public class TrainingAppDbContext : DbContext
	{
        public TrainingAppDbContext():base()
        {
        }

        public TrainingAppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrainingDB;Integrated Security=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>()
				.HasKey(x => x.ID);

			modelBuilder.Entity<Instructor>()
				.HasKey(x => x.ID);
			modelBuilder.Entity<Instructor>()
				.HasOne(x => x.Department)
				.WithMany(x => x.Instructors)
				.HasForeignKey(x => x.Dep_ID);
			modelBuilder.Entity<Instructor>()
				.HasOne(x => x.Course)
				.WithMany(x => x.Instructors)
				.HasForeignKey(x => x.Crs_ID);

			modelBuilder.Entity<Trainee>()
				.HasKey(x => x.ID);
			modelBuilder.Entity<Trainee>()
				.HasOne(x => x.Department)
				.WithMany(x => x.Trainees)
				.HasForeignKey(x => x.Dep_ID);
			modelBuilder.Entity<Trainee>()
				.HasMany(x => x.CrsResults)
				.WithOne(x => x.Trainee);

			modelBuilder.Entity<Course>()
				.HasKey(x => x.ID);
			modelBuilder.Entity<Course>()
				.HasMany(x => x.Instructors)
				.WithOne(x => x.Course)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<Course>()
				.HasMany(x => x.CrsResults)
				.WithOne(x => x.Course)
				.OnDelete(DeleteBehavior.SetNull);
			modelBuilder.Entity<Course>()
				.HasOne(x => x.Department)
				.WithMany(x => x.Courses)
				.HasForeignKey(x => x.Dep_ID);

			modelBuilder.Entity<CrsResult>()
				.HasKey(x => x.ID);
			modelBuilder.Entity<CrsResult>()
				.HasOne(x => x.Trainee)
				.WithMany(x => x.CrsResults)
				.HasForeignKey(x => x.Trainee_ID);
			modelBuilder.Entity<CrsResult>()
				.HasOne(x => x.Course)
				.WithMany(x => x.CrsResults)
				.HasForeignKey(x => x.Crs_ID);


		}
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
    }
}
