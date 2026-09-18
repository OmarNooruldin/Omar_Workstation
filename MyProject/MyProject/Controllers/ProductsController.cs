using Microsoft.AspNetCore.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Products> products = new List<Products>();

            Products prod_1 = new Products()
            {
                Id = 1,
                Name = "4K USB-C Multi-Display Docking Station",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSCIWVWZSC6w2WWOlVcIhAUWcw6yWc4aZN4Jdf0Mq1GiQ&s=10",
                Description = " A premium hub that lets users expand a single laptop USB-C port into multiple ports," +
                " supporting up to triple 4K monitors. It includes built-in high-speed data transfer and power delivery.",
                Price = 120
            };

            Products prod_2 = new Products()
            {
                Id = 2,
                Name = "Ergonomic Vertical Wireless Mouse",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQuBSbxIeM7CAyHRceLGqUM0IrkBZhQ05B9k8NzVjzP9Q&s=10",
                Description = " A specialized mouse shaped in a natural \"handshake\" posture (typically at a 58-degree angle)" +
                " to relieve wrist strain and prevent carpal tunnel syndrome. Features multi-device Bluetooth switching and adjustable DPI.",
                Price = 50
            };

            Products prod_3 = new Products()
            {
                Id = 3,
                Name = "Mechanical Hot-Swappable Keyboard",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmOlo7Aa982ws9-gZbWEs57PxQ4jE_YxxTktbzpXY6Yg&s=10",
                Description = "A compact, space-saving mechanical keyboard where users can easily swap out the key switches without soldering." +
                " Often features RGB backlighting and triple-mode connectivity (Bluetooth, 2.4GHz wireless, and USB-C).",
                Price = 90,
            };

            Products prod_4 = new Products()
            {
                Id = 4,
                Name = "Large Desk Mat with Integrated Wireless Charging",
                Image= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTboWGFV33vg4919q7-MUvs2IuBdrj5w__g2K2sq2qSpMYXRIZPvp4f&usqp=CAE&s",
                Description = "A wide felt or faux-leather desk pad that protects the tabletop while offering a dedicated," +
                " Qi-certified wireless charging section built right into the fabric to power phones and wireless earbuds seamlessly.",
                Price = 55
            };

            //Products prod_5 = new Products()
            //{
            //    Id = 5,
            //    Name = "",
            //    Description = "",
            //    Price = 
            //};

            //Products prod_6 = new Products()
            //{
            //    Id = 1,
            //    Name = "Ahmad",
            //    Description = "Ahmad@gmail",
            //    Price = 1000,
            //};

            //Products prod_7 = new Products()
            //{
            //    Id = 1,
            //    Name = "Ahmad",
            //    Description = "Ahmad@gmail",
            //    Price = 1000,
            //};

            //Products prod_8 = new Products()
            //{
            //    Id = 1,
            //    Name = "Ahmad",
            //    Description = "Ahmad@gmail",
            //    Price = 1000,
            //};

            //Products prod_9 = new Products()
            //{
            //    Id = 1,
            //    Name = "Ahmad",
            //    Description = "Ahmad@gmail",
            //    Price = 1000,
            //};

            //Products prod_10 = new Products()
            //{
            //    Id = 1,
            //    Name = "Ahmad",
            //    Description = "Ahmad@gmail",
            //    Price = 1000,
            //};

            products.Add(prod_1);
            products.Add(prod_2);
            products.Add(prod_3);
            products.Add(prod_4);
            //products.Add(prod_5);
            //products.Add(prod_6);
            //products.Add(prod_7);
            //products.Add(prod_8);
            //products.Add(prod_9);
            //products.Add(prod_10);

            return View(products);
        }
    }
}
