using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Areas.Admin.Models;

namespace WebApplication8.Areas.Admin.Controllers
{
    public class QuanLyController : AdminController
    {
        private readonly WebShopContext db;
        private readonly ApplicationDbContext sdb;
        public QuanLyController(WebShopContext _db,ApplicationDbContext _sdb) {
            db = _db;
            sdb = _sdb;
        }

        [Area("Admin")]
        public ActionResult Index()
        {

            //ViewBag.Orders = db.Orders.Where(x => x.OrderDate.ToString("yyyy-MM-dd") 
            //== DateTime.Now.ToString("yyyy-MM-dd") && x.Status > 0).ToList().Count;
            //ViewBag.Users = db.Customers.ToList().Count;
            //ViewBag.Product = db.Products.ToList().Count;
            //ViewBag.Category = db.Categories.ToList().Count;

            //try {
            //    //Thống kê doanh số của đơn hàng trong vòng 12 tháng trước
            //    var list_str = GetListDate(12);
            //   /* var amount_ = db.Orders.Where(x => x.Status == 2 && 
            //    x.OrderDate.ToString("yyyy-MM").CompareTo(list_str.ElementAt(0)) >= 0 && 
            //    x.OrderDate.ToString("yyyy-MM").CompareTo(list_str.ElementAt(list_str.Count - 1)) <= 0).Sum(x=>x.Amount);
            //    */
            //    //var 

            //    var LeftJoin_ = (from m in list_str
            //                     join o in db.Orders.Where(x => x.Status == 2).ToList() 
            //                     on m equals o.OrderDate.ToString("yyyy-MM") into JoinedDateOrder
            //                     from o in JoinedDateOrder.DefaultIfEmpty()
            //                     select new { Date = m, Count = o != null ? o.Amount : 0, Status = o != null ? o.Status : -1 })
            //                     .GroupBy(x => x.Date).Select(g => new DataChart { Label = g.Key, Value = g.Sum(x => x.Count).ToString() });


            //    var list_data = LeftJoin_.ToList();
            //    ViewBag.DataChart = list_data;
            //}
            //catch(Exception e) {
            //    Danger(string.Format("<b>Lỗi {0}</b>.", e.Message + e.InnerException.Message), false);
            //}
            return View();
        }
        public List<string> GetListDate(int count) {
            var list_ = new List<String>();
            // count = 12;
            var now_ = DateTime.Now;
            for (var i = 1; i <= count; i++) {
                var str_ = now_.AddMonths(-(i)).ToString("yyyy-MM");
                list_.Add(str_);
            }
            return list_;
        }
    }
}