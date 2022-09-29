using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using PMS.Models;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Categories");
        }
    }
}
