using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BlogAppApiDB;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=testtest123;");
        }

        public DbSet<Employee> Employees { get; set; }
        
    }
}

