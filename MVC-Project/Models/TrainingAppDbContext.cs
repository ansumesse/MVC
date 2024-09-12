using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Project.ViewModels;
using System.Drawing;
using System.Dynamic;

namespace MVC_Project.Models
{
	public class TrainingAppDbContext : IdentityDbContext<ApplicationUser>
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
            #region Note About override OnModelCreating When we inherite from identitydbcontext
        //    If you check your DbContext class, you’ll see that when you created an MVC app and choose to add.net Core Identity, your ApplicationDbContext class will inherit from IdentityDbContext.Within that parent class, there is some code that is necessary in setting up the Identity database.
        //When you override OnModelCreating without calling back up to the parent, it means that super-important code never gets called.
			#endregion
			base.OnModelCreating(modelBuilder);

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

			modelBuilder.Entity<RegisterViewModel>()
				.HasNoKey();
			modelBuilder.Entity<LoginViewModel>()
				.HasNoKey();
			modelBuilder.Entity<RoleViewModel>()
				.HasNoKey();

		}
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
	    public DbSet<MVC_Project.ViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;
	    public DbSet<MVC_Project.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
	    public DbSet<MVC_Project.ViewModels.RoleViewModel> RoleViewModel { get; set; } = default!;
    }
}
