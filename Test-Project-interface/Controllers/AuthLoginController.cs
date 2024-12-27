using Microsoft.AspNetCore.Mvc;

namespace Test_Project_interface.Controllers
{
    public class AuthLoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ForgotPass()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RecoverPass()
        {
            return View();
        }
    }
}
