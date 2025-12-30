// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using StudentCrudApi.Models;

namespace StudentCrudApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}