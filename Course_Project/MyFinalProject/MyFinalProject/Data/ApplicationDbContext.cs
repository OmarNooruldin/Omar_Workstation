using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
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

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

    }
}
