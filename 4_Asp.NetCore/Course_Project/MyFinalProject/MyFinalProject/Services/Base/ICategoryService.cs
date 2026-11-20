using FirstGroup_1.Controllers;
using MyFinalProject.Dtos;
using MyFinalProject.Models;

namespace MyFinalProject.Services.Base
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
