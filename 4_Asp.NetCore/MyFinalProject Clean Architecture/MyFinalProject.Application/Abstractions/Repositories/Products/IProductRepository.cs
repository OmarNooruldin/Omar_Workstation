using MyFinalProject.Application.Abstractions.Repositories.Base;
using MyFinalProject.Domain;

namespace MyFinalProject.Application.Abstractions.Repositories.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllProductWithCategories();
    }
}
