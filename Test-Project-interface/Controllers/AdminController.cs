﻿using Microsoft.AspNetCore.Mvc;

namespace Test_Project_interface.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
    }
}
