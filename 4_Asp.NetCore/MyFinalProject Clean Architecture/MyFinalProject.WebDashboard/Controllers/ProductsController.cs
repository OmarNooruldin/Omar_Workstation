
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using MyFinalProject.Infrastructure.Data;
using MyFinalProject.Application.Abstractions.Services;
using MyFinalProject.Application.Security;
using MyFinalProject.Application.Dtos;

[Authorize]
public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IProductService _productService;
    //private readonly IUnitOfWork _unitOfWork;
    //private readonly IRepository<Product> _proRepository;
    //private readonly IRepository<Category> _catRepository;

    public ProductsController(ApplicationDbContext context, IProductService productService)
    {
        _context = context;
        _productService = productService;
        //_unitOfWork = unitOfWork;
        //_proRepository = proRepository;
        //_catRepository = catRepository;
    }

    // GET: Products
    [Authorize(Policy =PermissionsNames.ProductView)]
    public async Task<IActionResult> Index()
    {
        return View(_productService.GetAllProducts());
    }

    // GET: PRODUCTS/Details/5
    [Authorize(Policy = PermissionsNames.ProductDetails)]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = _productService.GetProductById(id.Value);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }


    // GET: PRODUCTS/Create
    [Authorize(Policy = PermissionsNames.ProductCreate)]
    public IActionResult Create()
    {
        LoadCategory();
        return View();
    }

    // POST: PRODUCTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = PermissionsNames.ProductCreate)]
    public async Task<IActionResult> Create(ProductCreateDto product)
    {
        if (ModelState.IsValid)
        {
            _productService.CreateProduct(product);
            _productService.SaveProduct();
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        LoadCategory();
        return View(product);
    }

    // GET: PRODUCTS/Edit/5
    [Authorize(Policy = PermissionsNames.ProductEdit)]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product =  _productService.GetProductById(id.Value);
        if (product == null)
        {
            return NotFound();
        }
        LoadCategory();
        return View(product);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = PermissionsNames.ProductEdit)]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Description,Price,CategoryId")] ProductUpdateDto product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _productService.UpdateProduct(product);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _productService.SaveProduct();
            return RedirectToAction(nameof(Index));
        }
        LoadCategory();
        return View(product);
    }

    // GET: PRODUCTS/Delete/5
    [Authorize(Policy = PermissionsNames.ProductDelete)]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product =  _productService.GetProductById(id.Value);
        if (product == null)
        {
            return NotFound();
        }
        LoadCategory();
        return View(product);
    }

    // POST: PRODUCTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = PermissionsNames.ProductDelete)]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var product = _productService.GetProductById(id.Value);
        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
        }

        //await _context.SaveChangesAsync();
        _productService.SaveProduct();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int? id)
    {
        return _context.Products.Any(e => e.Id == id);
    }

    private void LoadCategory()
    {
        var categories = _productService.GetAllCategory();
        ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
    }
}
