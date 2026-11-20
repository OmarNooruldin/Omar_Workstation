using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Repositories.Products;
using MyFinalProject.Domain;
using MyFinalProject.Infrastructure.Data;
using MyFinalProject.Infrastructure.implementation.Repositories.Base;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Products
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
