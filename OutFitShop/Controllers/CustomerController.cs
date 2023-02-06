using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal.TypeHandlers.GeometricHandlers;
using OutFitShop.Data;
using OutFitShop.Models;
using System.Security.Claims;
using static Humanizer.On;

namespace OutFitShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public CustomerController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        

        [HttpGet]
        public async Task<IActionResult> Index(Category.Categ id)
        {

            

            if (id == Category.Categ.menn)
            {


                var find = _db.Products.Where(b => b.Categ.Equals(Category.Categ.menn));
                if (find != null)
                {

                   

                    return View(await find.ToListAsync());
                }
            }
            if (id == Category.Categ.women)
            {

                var find = _db.Products.Where(b => b.Categ.Equals(Category.Categ.women));
                if (find != null)
                {
                    return View(await find.ToListAsync());
                }
            }

            if (id == Category.Categ.babies)
            {
                var find = _db.Products.Where(b => b.Categ.Equals(Category.Categ.babies));
                if (find != null)
                {
                    return View(await find.ToListAsync());
                }
            }

            if (id == Category.Categ.accessories)
            {
                var find = _db.Products.Where(b => b.Categ.Equals(Category.Categ.accessories));
                if (find != null)
                {
                    return View(await find.ToListAsync());
                }
            }


            return View(new List<Product>());
        }
        [Authorize]
        [HttpGet]


        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
            return View(product);
        }



        //   [Authorize]
        //   [HttpPost]
        ////   [ActionName("Details")]
        //   public async Task<IActionResult> DetailsPost( int id = 1)
        //   {




        //           var prod = await _db.Products.FirstOrDefaultAsync(p => p.Id.Equals(1));
        //           var orderLine = new OrderLine(5);

        //           var order = await _db.Orders.FirstOrDefaultAsync(p => p.Id.Equals(1));

        //           orderLine.Product = prod;
        //           orderLine.ProductId = prod.Id;
        //           orderLine.Order = order;
        //           orderLine.OrderId = order.Id;

        //           _db.Add(orderLine);
        //           await _db.SaveChangesAsync();

        //           return RedirectToAction("Index", new { id = prod.Categ });


        //   }




        [HttpGet]
        [Authorize]
        //get the view to delete the selected post
        public async Task<IActionResult> DeleteItem(int? id)
        {
            var orderLine = await _db.OrderLines
                  .FirstOrDefaultAsync(m => m.Id == id);


            return View(orderLine);
        }

        [HttpPost]
        [Authorize]
        // delete the selected post
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (id == null || _db.OrderLines == null)
            {
                return NotFound();
            }

            var orderLine = await _db.OrderLines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderLine == null)
            {
                return NotFound();
            }
            _db.OrderLines.Remove(orderLine);
            await _db.SaveChangesAsync();
            return RedirectToAction("Cart");
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart(int Id)

        {
            if (ModelState.IsValid)
            {

                if (Id != 0)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var product = await _db.Products.FirstOrDefaultAsync<Product>(p => p.Id.Equals(Id));

                    //var order = new Order( DateTime.Now);
                    //order.User = user;
                    //_db.Orders.Add(order);
                    //await _db.SaveChangesAsync();

                    var orderLine = new OrderLine(4);
                    orderLine.Product = product;
                    //orderLine.Order = order;
                 


                    _db.OrderLines.Add(orderLine);
                    await _db.SaveChangesAsync();
                }
                
               

            }

             var find = await _db.OrderLines.ToListAsync();

            
                if (find.Count > 0)
                {
                    return View(find);
                }

            

            return View(new List<OrderLine>());
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyOrders()

        {
            

            var find = await _db.Orders.FirstOrDefaultAsync(p => p.Id.Equals(order.Id));
            if (find != null)
            {
                return View( find);
            }

            return View(new Order());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyOrders(List<OrderLine> orderLines)

        {
            orderLines = ViewBag.Model;
            var user = await _userManager.GetUserAsync(User);
            if(orderLines != null)
            {
                var order = new Order(DateTime.Now);
                order.User = user;

                order.OrderLines.AddRange(orderLines);

                _db.Orders.Add(order);
                await _db.SaveChangesAsync();

                return View(order);


            }
            


            


            return View(new Order());
        }



        public IActionResult Payment()
        {
            return View(new Order());
        }
    }
}
