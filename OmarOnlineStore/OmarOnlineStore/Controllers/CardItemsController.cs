using Microsoft.AspNetCore.Mvc;
using OmarOnlineStore.Data;
using OmarOnlineStore.Models;

namespace OmarOnlineStore.Controllers
{
    public class CardItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CardItem> cardItems = _context.CardItems.ToList();
            return View(cardItems);
        }

        [HttpGet]
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
        public IActionResult Delete(CardItem cardItem)
        {
            _context.CardItems.Remove(cardItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
