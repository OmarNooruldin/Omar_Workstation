using Microsoft.EntityFrameworkCore;
using OmarOnlineStore.Models;

namespace OmarOnlineStore.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
