using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Controllers
{
    public class HomeQLNHController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}