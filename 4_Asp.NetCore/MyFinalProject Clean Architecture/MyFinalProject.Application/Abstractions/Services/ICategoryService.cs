using MyFinalProject.Application.Dtos;

namespace MyFinalProject.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();

        void CreateCategory(CategoryCreateDto category);
        void UpdateCategory(CategoryUpdateDto category);
        void DeleteCategory(int Id);

        CategoryUpdateDto GetCategoryById(int Id);

        int SaveCategories();

    }
}
