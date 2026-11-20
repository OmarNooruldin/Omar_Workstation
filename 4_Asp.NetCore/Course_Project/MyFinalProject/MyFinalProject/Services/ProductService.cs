using MyFinalProject.Dtos;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Services.Base;

namespace MyFinalProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateProduct(ProductCreateDto product)
        {
            var products = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };
            _unitOfWork.Products.Add(products);
        }

        public void DeleteProduct(int Id)
        {
            var products = _unitOfWork.Products.GetById(Id);
            if (products == null)
            {
                throw new KeyNotFoundException("Product Not Found");
            }
            _unitOfWork.Products.Delete(products);
        }

        public IEnumerable<CategoryDto> GetAllCategory()
        {
            var category = _unitOfWork.Categories.GetAll();
            return category.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description= c.Description,
            });
        }

        public IEnumerable<ProductListDto> GetAllProducts()
        {
            var products = _unitOfWork.Products.GetAllProductWithCategories();
            return products.Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CategoryName = p.Category?.Name,
            });
        }

        public ProductUpdateDto GetProductById(int Id)
        {
            var products = _unitOfWork.Products.GetById(Id);
            if (products == null)
            {
                return null;
            }
            return new ProductUpdateDto
            {
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                CategoryId = products.CategoryId.Value,
            };
        }

        public int SaveProduct()
        {
            return _unitOfWork.Save();
        }

        public void UpdateProduct(ProductUpdateDto product)
        {
            var products = _unitOfWork.Products.GetById(product.Id);
            if (products == null)
            {
                throw new KeyNotFoundException("Product Not Found");
            }
            products.Name = product.Name;
            products.Description = product.Description;
            products.Price = product.Price;
            products.CategoryId = product.CategoryId;
            _unitOfWork.Products.Update(products);
        }
    }
}
