using Microsoft.EntityFrameworkCore;
using RemindMeApi.Models;

namespace RemindMeApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
