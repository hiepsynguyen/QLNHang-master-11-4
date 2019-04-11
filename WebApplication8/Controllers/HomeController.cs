using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Sakura.AspNetCore;
using WebApplication8.Data;
using WebApplication8.Models;
using WebApplication8.Models.ShoppingCart;
using WebApplication8.Models.WebShop;
using WebApplication8.Resources;

namespace WebApplication8.Controllers
{
    public class HomeController : BaseController
    {
        private readonly WebShopContext _webc;
        private readonly IShoppingCart shoppingc;
        private readonly ShoppingCart shop;
        private readonly IStringLocalizer<Globalization> _localizer;
        public HomeController(WebShopContext _db, IShoppingCart _shoppingcart, ShoppingCart _shop, IStringLocalizer<Globalization> localizer) : base(_db)
        {
            _webc = _db;
            shoppingc = _shoppingcart;
            shop = _shop;
            _localizer = localizer;
        }
        public IActionResult Index()
        {


            //var cart = new ShoppingCart(_webc);
            // shoppingc.TestSet();

            /* var s = shoppingc.TestGetString();
             var a = HttpContext.Session.GetString("a");
             var list = ShoppingCart.Items;
            

             shop__.Add(1061, 1);
             var p = ShoppingCart.Items.Single(i => i.Id == 1061);*/
            // Response.Cookies.
            //  var shop__ = shop.Cart();
            //var a = _localizer["new"];
            var model = db.Categories.Include(u => u.Products).ToList();

            var randomProducts = (from p in db.Products orderby Guid.NewGuid() select p).Take(10).ToList();
            ViewBag.Random = randomProducts;


            return View(model);

            //return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Header()
        {
            var cart = shop.Cart();
            try
            {
                //var cat = db.Categories.ToList();
                //ViewBag.Categories = cat;
                //var blankline = new Category();
                //blankline.Id = 0;
                //blankline.Name = "All";
                //blankline.NameVN = "All";
                //cat.Add(blankline);
                var query = db.Categories.ToList();




                var cat = new List<Category>();
                var BlankCat = new Category() { Id = 0, Name = "All", NameVN = "All" };
                cat.Add(BlankCat);


                var newTable = cat.Union(query);
                ViewBag.Categories = newTable;

            }
            catch
            {

            }

            try
            {


                //Xử lý sản phẩm yêu thích (Đang lỗi ...)
                // Lấy cookie cũ tên views
                /* var wishlist = Request.Cookies["wishlist"];
                 // Nếu chưa có cookie cũ -> tạo mới
                 if (wishlist == null)
                 {
                     wishlist = new HttpCookie("wishlist");
                 }

                 ViewBag.Count = wishlist.Values.Count;*/

            }
            catch
            {

            }

            return PartialView("Partials/_Header", ShoppingCart.Items);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String keywork, String cat, int? page)

        {

            ViewBag.tukhoa = keywork;

            //var model = db.Products.ToList();
            //var search = keywork.ToLower();
            //if (keywork != null)
            //{
            //    ViewBag.tukhoa = keywork;
            //    model = db.Products.Where(n => n.Name.ToLower().Contains(search)).ToList();
            //}
            //if (cat != null)
            //{
            //    model = db.Products.Where(n => n.Category.Name == cat).ToList();
            //}




            //var model = db.Products
            //.Where(x => (keyword == null || x.Name.Contains(keywork, StringComparison.OrdinalIgnoreCase))
            //&& (cat == null || x.Category.Name == cat)
            //).ToList();
            if (cat == "All")
            {
                cat = null;
            }

            var model = from s in db.Products.Include(u => u.Category).Include(u => u.Supplier).ToList()
                        where ((string.IsNullOrEmpty(keywork) ? true : s.Name.ToLower().Contains(keywork.ToLower())) &&
                               (string.IsNullOrEmpty(cat) ? true : s.Category.Name == cat) || (s.Category.NameVN == cat))
                        select s;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            // return View(students.ToPagedList(pageNumber, pageSize));
            return PartialView("Partials/_Search", model.ToPagedList(pageSize, pageNumber));
        }

        public ActionResult Culture(string id)
        {
            HttpContext.Response.Cookies.Append("Culture", id, new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1),
                Secure = false,

            });

            return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }));
        }


    }
}
