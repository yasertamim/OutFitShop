using Microsoft.AspNetCore.Mvc;

namespace OutFitShop.Controllers
{
    public class CustomerController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
