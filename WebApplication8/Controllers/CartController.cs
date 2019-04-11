using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models.ShoppingCart;
using WebApplication8.Data;

namespace WebApplication8.Controllers
{
    public class CartController : BaseController
    {
        private readonly WebShopContext _webc;
        private readonly IShoppingCart shoppingc;
        private readonly ShoppingCart shop;
        public CartController(WebShopContext _db, IShoppingCart _shoppingcart, ShoppingCart _shop)
            :base(_db) {
            _webc = _db;
            shoppingc = _shoppingcart;
            shop = _shop;
        }
        public ActionResult Index()
        {
           // var cart = shop.Cart();
            return View(ShoppingCart.Items);

        }
        public ActionResult OrderDetail()
        {
            // var cart =shop.Cart();
            return PartialView("Partials/_OrderDetail", ShoppingCart.Items);
        }


        public ActionResult PartialCart()
        {
            //var cart = shop.Cart();
            return PartialView("Partials/_PartialCart", ShoppingCart.Items);

        }



        public IActionResult Add(int id, int soluong)
        {

            /*var cart = shop.Cart();
            cart.Add(id, soluong);
            var p = ShoppingCart.Items.Single(i => i.Id == id);*/
             var cart = shop.Cart();
             cart.Add(id, soluong);


             var info = new { Count=ShoppingCart.Count,Total= ShoppingCart.Total.ToString("#,000") };
            // HttpContext.Session.Get
            //var cart = shop.Cart();


            return Json(info);
        }

        public ActionResult Remove(int id)
        {
             var cart = shop.Cart();
             cart.Remove(id);

             var info = new { ShoppingCart.Count, Total=ShoppingCart.Total.ToString("#,000") };
            return Json(info);
        }

        public ActionResult Update(int id, int quantity)
        {
            var cart = shop.Cart();
            cart.Update(id, quantity);

            var p = ShoppingCart.Items.Single(i => i.Id == id);
            var info = new
            {
               Count= ShoppingCart.Count,
               Total= ShoppingCart.Total.ToString("#,000"),
                quantity = quantity,
                Amount = (p.PriceP * p.Quantity * (1 - p.Discount)).ToString("#,000")
            };
            return Json(info);
        }

        public ActionResult Clear()
        {

            var cart = shop.Cart();
            cart.Clear();
            return RedirectToAction("Index");
        }
    }
}