using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmarOnlineStore.Data;
using OmarOnlineStore.Models;
using OmarOnlineStore.Security;

namespace OmarOnlineStore.Controllers
{
    [Authorize]
    public class CardItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Authorize(Policy = PermissionsNames.CardItemView)]
        public IActionResult Index()
        {
            List<CardItem> cardItems = _context.CardItems.ToList();
            return View(cardItems);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.CardItemDetails)]
        public IActionResult Details(int Id)
        {
            CardItem? cardItem = _context.CardItems.Find(Id);
            if (cardItem == null)
            {
                return NotFound();
            }
            return View(cardItem);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.CardItemCreate)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.CardItemCreate)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CardItem cardItem)
        {
            if (ModelState.IsValid)
            {
                _context.CardItems.Add(cardItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardItem);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.CardItemEdit)]
        public IActionResult Edit(int Id)
        {
            CardItem? cardItem = _context.CardItems.Find(Id);
            if (cardItem == null)
            {
                return NotFound();
            }
            return View(cardItem);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.CardItemEdit)]
        public IActionResult Edit(CardItem cardItem)
        {
            if (ModelState.IsValid)
            {
                _context.CardItems.Update(cardItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardItem);
        }

        [HttpGet]
        [Authorize(Policy =PermissionsNames.CardItemDelete)]
        public IActionResult Delete(int Id)
        {
            CardItem? cardItem = _context.CardItems.Find(Id);
            if (cardItem == null)
            {
                return NotFound();
            }
            return View(cardItem);
        }

        [HttpPost]
        [Authorize(Policy =PermissionsNames.CardItemDelete)]
        public IActionResult Delete(CardItem cardItem)
        {
            _context.CardItems.Remove(cardItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
