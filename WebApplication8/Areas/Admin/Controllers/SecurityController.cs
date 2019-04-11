using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Authentication;

namespace WebApplication8.Areas.Admin.Controllers
{
    public class SecurityController : AdminController
    {
        protected ApplicationDbContext sdb ;


        public UserManager<ApplicationUser> UserManager;
        public RoleManager<ApplicationRole> RoleManager;
        public SecurityController(ApplicationDbContext _sdb, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager)
        {
            sdb = _sdb;
            UserManager = _userManager;
            RoleManager = _roleManager;
        }

        [Area("Admin")]
        public async void SignOut(string schema)
        {
            await AuthenticationManager.SignOutAsync(schema);
        }

        [Area("Admin")]
        public void SignIn(ApplicationUser user, bool isPersistent)
        {
           // AuthenticationManager.SignOutAsync(user.UserName);
           // var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
           // var identity = 
           // AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }


        private AuthenticationManager AuthenticationManager
        {
            get
            {
                
                return HttpContext.Authentication;
            }
        }

        /* protected override void Dispose(bool disposing)
         {
             //if (disposing && UserManager != null)
             //{
             //    UserManager.Dispose();
             //    UserManager = null;
             //}
             //if (disposing && RoleManager != null)
             //{
             //    RoleManager.Dispose();
             //    RoleManager = null;
             //}
             //base.Dispose(disposing);
             sdb.Dispose();
             base.Dispose(disposing);
         }*/
    }
}