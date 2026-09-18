using Microsoft.EntityFrameworkCore;
using MyFinalProject.Models;

namespace MyFinalProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        //Define Your DbSets here
        // public DbSet<YourEntity> YourEntity { get; set; }

        public DbSet<Employee> Employee { get; set; }


    }
}
