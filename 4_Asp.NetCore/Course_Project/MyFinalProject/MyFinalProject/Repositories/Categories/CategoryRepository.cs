using MyFinalProject.Data;
using MyFinalProject.Models;
using MyFinalProject.Repositories.Base;

namespace MyFinalProject.Repositories.Categories
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
