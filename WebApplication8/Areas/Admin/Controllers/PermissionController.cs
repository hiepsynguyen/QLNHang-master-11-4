using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.Data;
using Microsoft.AspNetCore.Identity;
using WebApplication8.Models;

namespace WebApplication8.Areas.Admin.Controllers
{
    public class PermissionController : SecurityController
    {
        public PermissionController(ApplicationDbContext _sdb, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager) : base(_sdb, _userManager, _roleManager)
        {

        }
        [Area("Admin")]
        public ActionResult Index(String RoleName = "", String ControllerName = "")
        {
            var roles = sdb.Roles.ToList();
            var controllers = sdb.WebActions
                .Select(a => a.Controller).Distinct().ToList();

            if (RoleName == "" && roles.Count > 0)
            {
                RoleName = roles.First().Name;
            }

            if (ControllerName == "" && controllers.Count > 0)
            {
                ControllerName = controllers.First();
            }

            var role = sdb.Roles.Single(r => r.Name == RoleName);


            /* var webacinserts = from c in sdb.WebActions
                                where !sdb.Permissions.Any(p=>p.WebActionId==c.Id && p.RoleId==role.Id)
                                select c;
             if (webacinserts.Any())
             {
                 foreach (var a in webacinserts)
                 {

                     try
                     {


                             var p = new Permission
                             {
                                 WebActionId = a.Id,
                                 RoleId = role.Id,
                                 Allowable = false
                             };
                             sdb.Permissions.Add(p);
                         }

                     catch(Exception e)
                     {
                         ModelState.AddModelError("", e.InnerException);
                         Danger(string.Format("<b>{0}</b> Thêm b? l?i.", e.Message + e.InnerException), true);
                     }
                 }
                 sdb.SaveChanges();

             }*/
            //else
            //{
            //    var perms = sdb.Permissions
            //        .Where(p => p.RoleId == role.Id)
            //        .ToList();
            //    if (perms.Count == 0)
            //    {
            //        foreach (var a in sdb.WebActions)
            //        {
            //            var p = new Permission
            //            {
            //                WebActionId = a.Id,
            //                RoleId = role.Id,
            //                Allowable = false
            //            };
            //            sdb.Permissions.Add(p);
            //        }

            //    }
            //}
         

            ViewBag.RoleName = new SelectList(roles, "Name", "Name", RoleName);
            ViewBag.ControllerName = new SelectList(controllers, ControllerName);
            ViewBag.Permissions = sdb.Permissions.Where(p => p.RoleId == role.Id && p.Action.Controller == ControllerName).ToList();


            ViewBag.ActionName = sdb.WebActions.Where(p => p.Controller == ControllerName).ToList();

            return View();
        }



        //----------------------------//
        [Area("Admin")]
        public ActionResult Update(int id, bool allowable)
        {
            var p = sdb.Permissions.SingleOrDefault(u=>u.Id==id);
            p.Allowable = allowable;
            sdb.SaveChanges();
            return Content("OK");
        }
    }
}