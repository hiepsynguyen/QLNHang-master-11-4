using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Models.WebShop;
using Microsoft.AspNetCore.Http;
using WebApplication8.Models.UtilEntities;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;

namespace WebApplication8.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ProductController(WebShopContext _db, IHttpContextAccessor httpContextAccessor) : base(_db)
        {
            _httpContextAccessor = httpContextAccessor;
            Products_ = new List<Product>();
        }

        public static List<Product> Products_ ;
        public  List<string> Products
        {
            get
            {
                // L?y ra t? Session
                //  var list = Session["Products"] as List<Product>;
                var list = _session.GetObject<List<string>>("Products");
                if (list == null) // ch?a có trong Session
                {
                    list = new List<string>();
                   // Session["Products"] = list; // b? vào Session
                    _session.SetObject("Products",list);
                }
                return list;
            }
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Cat(int Id)
        {
            var model = db.Categories.Include(u=>u.Products).SingleOrDefault(u=>u.Id==Id).Products.ToList();
            ViewBag.CategoryName = db.Categories.SingleOrDefault(u=>u.Id==Id);
            return View("Cat", model);
        }
        public ActionResult Detail(int Id)
        {
            var model = db.Products.Include(u=>u.Category).Include(u=>u.Supplier).SingleOrDefault(u=>u.Id==Id);
            model.Views++;
            db.SaveChanges();
            ViewBag.PriceOff = model.PriceP * (1 - model.Discount);
          //  Products_ = Products;
           var list = Products;
            var m = list.Find(u=>u.Contains(model.Id.ToString()));
            
            if (m == null)
            {
                list.Add(model.Id+"");
               // list_.Add(model);
                _session.SetObject("Products", list);
               // var list__ = _session.GetObject<string[]>("Products");
            }

            if (list.Count > 10)
            {
                ViewBag.Views = getListProduct(list).Take(10);
            }
            else
            {
                ViewBag.Views = getListProduct(list);
            }
            return View("Detail", model);
        }
        //Chức năng đang test
        public ActionResult AddToWishList(int Id)
        {
            /*  
           try
           {

               // L?y cookie c? tên views
               var wishlist = Request.Cookies["wishlist"];
               var ProductName = db.Products.SingleOrDefault(p => p.Id == Id);
               // N?u ch?a có cookie c? -> t?o m?i
               if (wishlist == null)
               {
                  // wishlist = new HttpCookie("wishlist");
                   wishlist = Response.Cookies.Append("","");
               }
               // B? sung m?t hàng ?ã xem vào cookie
               if (wishlist[Id.ToString()] == null)
               {

                   wishlist.Values[Id.ToString()] = Id.ToString();
                   Success(string.Format("<b><h4>{0}</h4></b> ?ã ???c thêm vào danh sách ?a thích thành công.", ProductName.Name), true);
               }

               // ??t th?i h?n t?n t?i c?a cookie
               wishlist.Expires = DateTime.Now.AddMonths(1);
               // G?i cookie v? client ?? l?u l?i
               Response.Cookies.Add(wishlist);

               // L?y List<int> ch?a mã hàng ?ã xem t? cookie
               var keys = wishlist.Values
                   .AllKeys.Select(k => int.Parse(k)).ToList();
               // Truy v?n hàng ?ang xem
               ViewBag.WishList = db.Products
                   .Where(p => keys.Contains(p.Id));
               ViewBag.Count = wishlist.Values.Count;




           }
           catch
           {

           }
           */
            return RedirectToAction("Index", "Home");
        }
        //Ch?c n?ng dang test
        public ActionResult MyWishList()
        {
            /*
            var wishlist = Request.Cookies["wishlist"];
            // N?u ch?a có cookie c? -> t?o m?i
            if (wishlist == null)
            {
                wishlist = new HttpCookie("wishlist");
            }
            var keys = wishlist.Values
                .AllKeys.Select(k => int.Parse(k)).ToList();
            // Truy v?n háng ?ãn xem
            ViewBag.WishList = db.Products
                .Where(p => keys.Contains(p.Id))
                .Take(10);
                */
            return View();
        }

        public ActionResult RemoveFromWishList(int Id)
        {
            /* try
             {

                 var ProductName = db.Products.SingleOrDefault(p => p.Id == Id);
                 var wishlist = Request.Cookies["wishlist"];


                 if (wishlist.HasKeys)
                 {
                     wishlist.Values.Remove(Id.ToString());
                 }
                 Response.SetCookie(wishlist);
                 Success(string.Format("<b><h4>{0}</h4></b> ?ã ???c xoá thành công.", ProductName.Name), true);
             }
             catch
             {

             }


             // B? sung m?t hàng ?ã xem vào cookie
             // wishlist.Values[Id.ToString()].Remove
              */
            return RedirectToAction("MyWishList", "Product");
           
        }


        public ActionResult ListBySpecial(string Id, int? page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            List<Product> model = null;
            switch (Id)
            {
                case "Best":
                    model = db.Products.Include(u=>u.Supplier).Include(u=>u.Category).ToList();
                    ViewBag.Id = Id;

                    break;
                case "Latest":
                    model = db.Products.Include(u => u.Supplier).Include(u => u.Category)
                        .Where(p => p.Latest).ToList();
                    ViewBag.Id = Id;

                    break;
                case "Special":
                    model = db.Products.Include(u => u.Supplier).Include(u => u.Category)
                        .Where(p => p.Special).ToList();
                    ViewBag.Id = Id;
                    break;
                case "SalesOff":
                    model = db.Products.Include(u => u.Supplier).Include(u => u.Category)
                        .Where(p => p.Discount > 0)
                        .OrderByDescending(p => p.Discount).ToList();
                    ViewBag.Id = Id;
                    break;
                case "Favorite":
                    model = db.Products.Include(u => u.Supplier).Include(u => u.Category).ToList();
                    ViewBag.Id = Id;
                    break;
                case "Views":
                    model = db.Products.Include(u => u.Supplier).Include(u => u.Category)
                        .Where(p => p.Views > 0)
                        .OrderByDescending(p => p.Views)
                        .Take(12).ToList();
                    ViewBag.Id = Id;
                    break;


                default:
                    model = db.Products.Include(u => u.Supplier).Include(u => u.Category)
                        .Where(p => p.SupplierId == Id).ToList();
                    ViewBag.Id = Id;
                    break;
            }

            // return View(students.ToPagedList(pageNumber, pageSize));
            // return PartialView("Partials/_Search", model.ToPagedList(pageNumber, pageSize));
            return View("ProductList", model.ToPagedList(pageSize,pageNumber));
        }
        public List<Product> getListProduct(List<string> arr_id) {
            var list_ = new List<Product>();
            foreach (var s in arr_id) {
                var pr = db.Products.Include(u => u.Category).Include(u => u.Supplier).SingleOrDefault(u=>u.Id.ToString()==s);
                if (pr!=null) {
                    list_.Add(pr);
                }
            }
            return list_;
        }
    }
}