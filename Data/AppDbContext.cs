using Microsoft.EntityFrameworkCore;
using CrudApp.Models.Entities;

using CrudApp.Data;

namespace CrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
