using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;

namespace WebApplication8.Controllers
{
    public class ValidatingController : BaseController
    {
        private readonly ApplicationDbContext sdb ;

        public ValidatingController(ApplicationDbContext _sdb, WebShopContext _db) : base(_db)
        {
            sdb = _sdb;
        }

        public JsonResult IsUserExists(string Email)
        {
            var model = new { valid = !sdb.Users.Any(x => x.Email == Email) };
            return Json(model);
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

        }

        public JsonResult IsRoleExists(string NewRoleName)
        {
            var model = new { valid = !sdb.Roles.Any(x => x.Name == NewRoleName) };
            return Json(model);


        }
        public JsonResult IsSupplierExists(string Id)
        {
            var model = new { valid = !db.Suppliers.Any(x => x.Id == Id) };
            return Json(model);


        }
    }
}