using Microsoft.EntityFrameworkCore;
using WorkintechDeployDemo02.Models;

namespace WorkintechDeployDemo02
{
    public class WorkintechSqliteContext:DbContext
    {
        public DbSet<City> Cities { get; set; }
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           {
                   optionsBuilder.UseSqlite("Data Source=workintech.db");
          }
       }
}
