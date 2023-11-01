using Microsoft.EntityFrameworkCore;
using TaskBoard.DAL.Configurations;
using TaskBoard.Domain.Models;

namespace TaskBoard.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B2NPS3T;Database=TaskBoard;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<SprintEntity> Sprints { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new SprintConfiguration());

            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
