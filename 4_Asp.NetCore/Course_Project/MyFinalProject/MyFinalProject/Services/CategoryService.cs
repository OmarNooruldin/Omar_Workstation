using MyFinalProject.Dtos;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;
using MyFinalProject.Repositories.Categories;
using MyFinalProject.Services.Base;

namespace MyFinalProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCategory(CategoryCreateDto category)
        {
            var categories = new Category
            {
                Name = category.Name,
                Description = category.Description,
            };
            _unitOfWork.Categories.Add(categories);
        }

        public void DeleteCategory(int Id)
        {
            var categories = _unitOfWork.Categories.GetById(Id);
            if (categories == null)
            {
                throw new KeyNotFoundException("Category Not Found");
            }
            _unitOfWork.Categories.Delete(categories);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            });
        }

        public CategoryUpdateDto GetCategoryById(int Id)
        {
            var categories = _unitOfWork.Categories.GetById(Id);
            if(categories == null)
            {
                return null;
            }
            return new CategoryUpdateDto
            {
                Id = categories.Id,
                Name = categories.Name,
                Description= categories.Description,
            };
        }

        public int SaveCategories()
        {
            return _unitOfWork.Save();
        }

        public void UpdateCategory(CategoryUpdateDto category)
        {
            var categories = _unitOfWork.Categories.GetById(category.Id);
            if (categories == null)
            {
                throw new KeyNotFoundException("Category Not Found");
            }
            categories.Name = category.Name;
            categories.Description = category.Description;

            _unitOfWork.Categories.Update(categories);
        }
    }
}
