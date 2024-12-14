using Microsoft.AspNetCore.Mvc;

namespace Test_Project_interface.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
