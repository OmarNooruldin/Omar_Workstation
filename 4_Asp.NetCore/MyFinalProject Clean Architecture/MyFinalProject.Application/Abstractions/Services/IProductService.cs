using MyFinalProject.Application.Dtos;


namespace MyFinalProject.Application.Abstractions.Services
{
    public interface IProductService
    {
        IEnumerable<ProductListDto> GetAllProducts();

        void CreateProduct(ProductCreateDto product);
        void UpdateProduct(ProductUpdateDto product);
        void DeleteProduct(int Id);

        ProductUpdateDto GetProductById(int Id);

        IEnumerable<CategoryDto> GetAllCategory();

        int SaveProduct();
    }
}
