using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Utils;
using WebApplication8.Data;

namespace WebApplication8.Controllers
{
    public class BaseController : CommonCotroller
    {
       public readonly  WebShopContext db ;
        public BaseController(WebShopContext _db) {
            db = _db;
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}