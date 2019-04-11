using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication8.Models;
using WebApplication8.Models.WebShop;
using WebApplication8.Models.UtilEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Areas.Admin.Controllers
{
    public class MasterController : SecurityController
    {
        WebShopContext db;
        public MasterController(ApplicationDbContext _sdb, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager,WebShopContext _db) : base(_sdb,_userManager,_roleManager )
        {
            db = _db;
        }
        [Area("Admin")]
        public ActionResult Index()
        {
            var check = CheckRoleAdmin(User.Identity.Name);
            if (!check)
            {
                Danger(string.Format("<b>Bạn không có quyền truy cập chức năng Master{0}</b>", ""), true);
                return Redirect(Url.RouteUrl( new {controller="QuanLy",action="Index" ,area="Admin"}));
            }
            ViewBag.Users = UserManager.Users/*.Include(u => u.)*/.ToList(); //.Where(u => u.Roles.Count > 0);

            ViewBag.Roles = RoleManager.Roles/*.Include(u => u.Users)*/.ToList();

            ViewBag.OldRoleName = new SelectList(sdb.Roles, "Name", "Name");
            return View();
            //return 
        }
        [Area("Admin")]
        public async Task<ActionResult> AddRole(string NewRoleName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /* var role = new ApplicationRole();
                     role.Name = NewRoleName;*/
                    var role__ = new ApplicationRole() {
                        Name=NewRoleName
                    };
                IdentityResult roleRuslt = await RoleManager.CreateAsync(new ApplicationRole { Name = NewRoleName});
                    // sdb.Roles.Add(role);
                    //  sdb.SaveChanges();
                    Success(string.Format("<b>{0}</b> tạo thành công.", NewRoleName), true);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error" + e.InnerException);
                Danger(string.Format("<b> Lỗi {0}</b>", e.Message + e.InnerException), true);
            }

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        [HttpPost]
        public ActionResult RemoveRole(String OldRoleName)
        {
            try
            {
                var role = sdb.Roles.Single(r => r.Name == OldRoleName);
                sdb.Roles.Remove(role);
                sdb.SaveChanges();
                Success(string.Format("<b>{0}</b> Xoá thành công.", OldRoleName), true);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error" + e.InnerException);
                Danger(string.Format("<b>Lỗi {0}</b>", e.Message + e.InnerException), true);
            }

            return RedirectToAction("Index");
        }

        /*
         * USER
         */
        //public async Task<ActionResult> AddUser(String UserName, String Password, String[] Roles)
        //{
        //    var user = new ApplicationUser();
        //    user.UserName = UserName;

        //    var result = await UserManager.CreateAsync(user, Password);

        //    if (result.Succeeded)
        //    {
        //        sdb.SaveChanges();
        //        foreach (var role in Roles)
        //        {
        //            await UserManager.AddToRoleAsync(user.Id, role);
        //            sdb.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("/");
        //}
        [Area("Admin")]
        public async Task<ActionResult> AddUser(String Email, String Password, String Fullname, String[] UserRoles)
        {

            var user = new ApplicationUser();
            user.UserName = Email;
            user.Email = Email;


            var result = await UserManager.CreateAsync(user, Password);


            if (result.Succeeded)
            {

                try
                {
                    Customer cus = new Customer();
                    cus.Id = Email;
                    cus.Email = Email;
                    cus.Password = Security_D_E.EncryptString(Password,Security_D_E.key_e_d);
                    cus.Fullname = Fullname;
                    cus.Activated = true;

                    db.Customers.Add(cus);
                    db.SaveChanges();
                    Success(string.Format("<b>User {0}</b> tạo thành công.", Email), true);
                }
                catch (Exception e)
                {
                    Danger(string.Format("<b>Lỗi thêm Customer {0}</b>", e.Message), true);
                }



                try
                {
                    if (UserRoles.Length > 0 || UserRoles != null)
                    {
                        foreach (var role in UserRoles)
                        {
                            await UserManager.AddToRoleAsync(user, role);
                        }
                    }



                }
                catch(Exception e)
                {

                    Danger(string.Format("<b>Lỗi thêm Customer {0}</b>", e.Message), true);
                }
            }

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        public async Task<ActionResult> RemoveUser(String UserName)
        {
            try
            {
                var user = await UserManager.FindByNameAsync(UserName);
                foreach (var ur in await UserManager.GetRolesAsync(user) /*user.Roles.ToList()*/)
                {

                    //await UserManager.RemoveFromRoleAsync(user, ur.RoleId);
                    await UserManager.RemoveFromRoleAsync(user,ur);
                }

                sdb.Users.Remove(user);

                sdb.SaveChanges();
                Success(string.Format("<b>User {0}</b> xoá thành công.", UserName), true);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error" + e.InnerException);
                Danger(string.Format("<b>{0}</b> xoá bị lỗi", e.Message + e.InnerException), true);
            }

            return RedirectToAction("Index");
        }

        [Area("Admin")]
        public async Task<ActionResult> ResetPassword(string Id)
        {
            var user = await UserManager.FindByIdAsync(Id);
            ViewBag.UserName = user.UserName;
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public async Task<ActionResult> ResetPassword(string Id, string Password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.FindByIdAsync(Id);
                    ViewBag.UserName = user.UserName;
                    await UserManager.RemovePasswordAsync(user);
                    await UserManager.AddPasswordAsync(user, Password);
                    Success(string.Format("<b>User {0}</b> reset mật khẩu" + Password + " thành công.", user.UserName), true);
                    return RedirectToAction("Index", "Master");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Error" + e.InnerException);
                Danger(string.Format("<b>{0}</b> reset password user lỗi", e.Message + e.InnerException), true);
            }
            return View();
        }

        [Area("Admin")]
        public async Task<ActionResult> UpdateRole(String Name, bool Status, String UserName)
        {
            var user = await UserManager.FindByNameAsync(UserName);
            
            if (Status == true)
            {
                await UserManager.AddToRoleAsync(user, Name);
            }
            else
            {
                await UserManager.RemoveFromRoleAsync(user, Name);
            }
            return Content("Cập nhật thành công !");
        }
        public bool CheckRoleAdmin(String UserName)
        {
            var f = User.IsInRole("Administrators");
            /*var user = await UserManager.FindByNameAsync(UserName);
            if (user!=null) {
               var id_role= RoleManager.Roles.Where(u => u.Name == "Administrators").SingleOrDefault().Id;
                if (id_role!=null) {
                    var count = user.Roles.Count(u=>u.RoleId==id_role);
                    if (count > 0) return true;
                }
            }*/
            return f;
        }


    }
}