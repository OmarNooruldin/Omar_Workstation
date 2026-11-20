using MyFinalProject.Application.Abstractions.Repositories.Categories;
using MyFinalProject.Infrastructure.Data;

namespace MyFinalProject.Infrastructure.implementation.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
