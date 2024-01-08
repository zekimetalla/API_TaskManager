using Microsoft.EntityFrameworkCore;

namespace TaskManagerApp.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext>options)
            :base(options)
        {
        }
        public DbSet<TaskManagerApp.Models.Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>().HasKey(t => t.Id);

        } 
    }
}
