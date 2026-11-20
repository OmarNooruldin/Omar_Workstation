using Microsoft.EntityFrameworkCore;
using MyFinalProject.Data;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;

namespace MyFinalProject.Repositories.Products
{
    public class ProductRepository : Repository<Product> ,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Product> GetAllProductWithCategories()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
    }
}
