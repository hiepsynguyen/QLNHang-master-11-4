using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using WebApplication8.Models;
using WebApplication8.Data;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication8.Areas.Admin.Controllers
{
    public class TestApplicationController : Controller
    {

        public UserManager<ApplicationUser> UserManager;
        public RoleManager<ApplicationRole> RoleManager;
        public TestApplicationController(UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager) {

            UserManager = _userManager;
            RoleManager = _roleManager;

        }

        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}