﻿using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
