using Microsoft.EntityFrameworkCore;

namespace NorthwindApp.Model
{
    public class MyDbContext :  DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-D3J7FCU;Initial Catalog=NORTHWIND;Integrated Security=True");
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
