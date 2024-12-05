using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class AppDbContext : DbContext
    {
        #region DBSets
        public DbSet<Course> courses { get; set; }
        public DbSet<CrsResult> crsResults { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Trainee> trainees { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetSection("ConnectionStrings").Value);
        }

    }
}
