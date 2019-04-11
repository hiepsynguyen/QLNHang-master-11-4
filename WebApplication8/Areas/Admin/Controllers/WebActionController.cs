using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication8.Areas.Admin.Controllers
{
    public class WebActionController : SecurityController
    {
        public WebActionController(ApplicationDbContext _sdb, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager) : base(_sdb, _userManager, _roleManager)
        {

        }

        [Area("Admin")]
        public ActionResult Index()
        {
            ViewBag.WebActions = sdb.WebActions;
            return View();
        }

        [Area("Admin")]
        public ActionResult Insert(WebAction model)
        {
            try
            {
                sdb.WebActions.Add(model);
                sdb.SaveChanges();
                ModelState.AddModelError("", "?ã thêm");
            }
            catch
            {
                ModelState.AddModelError("", "L?i");
            }

            ViewBag.WebActions = sdb.WebActions;
            return View("Index", model);
        }

        [Area("Admin")]
        public ActionResult Update(WebAction model)
        {
            try
            {
                sdb.Entry(model).State = EntityState.Modified;
                sdb.SaveChanges();
                ModelState.AddModelError("", "?ã c?p nh?t");
            }
            catch
            {
                ModelState.AddModelError("", "L?i");
            }

            ViewBag.WebActions = sdb.WebActions;
            return View("Index", model);
        }

        [Area("Admin")]
        public ActionResult Delete(int Id)
        {
            try
            {
                var model = sdb.WebActions.SingleOrDefault(u=>u.Id==Id);
                sdb.WebActions.Remove(model);
                sdb.SaveChanges();
                ModelState.AddModelError("", "?ã xoá");
            }
            catch
            {
                ModelState.AddModelError("", "L?i");
            }

            ViewBag.WebActions = sdb.WebActions;
            return View("Index");
        }

        [Area("Admin")]
        public ActionResult Edit(int Id)
        {
            var model = sdb.WebActions.SingleOrDefault(u => u.Id == Id);

            ViewBag.WebActions = sdb.WebActions;
            return View("Index", model);
        }
    }
}