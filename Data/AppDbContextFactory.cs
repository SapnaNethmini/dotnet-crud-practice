using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentCrudApi.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
    
            var connectionString = "server=localhost;port=3306;database=studentdb;user=root;password=root";
            
            optionsBuilder.UseMySql(
                connectionString, 
                new MySqlServerVersion(new Version(8, 0, 21))
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}