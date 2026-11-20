using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;

namespace MyFinalProject.Repositories.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllProductWithCategories();
    }
}
