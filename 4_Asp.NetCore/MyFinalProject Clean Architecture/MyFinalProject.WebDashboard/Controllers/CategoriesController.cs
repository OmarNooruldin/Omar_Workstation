using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFinalProject.Application.Abstractions.Services;
using MyFinalProject.Application.Dtos;
using MyFinalProject.Application.Security;

namespace FirstGroup_1.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IRepository<Category> _catRepository;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            //_context = context;
            //_catRepository = catRepository;
            //_unitOfWork = unitOfWork;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.CategoryView)]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        //Get : Category Deatils
        [Authorize(Policy =PermissionsNames.CategoryDetails)]
        public IActionResult Details(int Id)
        {
            var cat = _categoryService.GetCategoryById(Id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.CategoryCreate)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = PermissionsNames.CategoryCreate)]
        public IActionResult Create(CategoryCreateDto cat)
        {
            if (ModelState.IsValid)
            {
                //_unitOfWork.Categories.Add(cat);
                //_unitOfWork.Save();
                _categoryService.CreateCategory(cat);
                _categoryService.SaveCategories();
                return RedirectToAction("Index");
            }
            return View(cat);

        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.CategoryUpdate)]
        public IActionResult Update(int Id)
        {
            var category = _categoryService.GetCategoryById(Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(CategoryUpdateDto cat)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(cat);
                _categoryService.SaveCategories();
                return RedirectToAction("Index");
            }
            return View(cat);
        }
        [HttpGet]
        [Authorize(Policy =PermissionsNames.DepartmentDelete)]
        public IActionResult Delete(int Id)
        {
            var cat = _categoryService.GetCategoryById(Id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }
        [HttpPost]
        [Authorize(Policy = PermissionsNames.DepartmentDelete)]
        public IActionResult Delete(CategoryUpdateDto cat)
        {
            _categoryService.DeleteCategory(cat.Id);
            _categoryService.SaveCategories();
            return RedirectToAction("Index");
        }
    }
}