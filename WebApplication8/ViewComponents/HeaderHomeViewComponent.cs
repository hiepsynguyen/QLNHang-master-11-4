using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;
using WebApplication8.Models.ShoppingCart;
using WebApplication8.Models.WebShop;

namespace WebApplication8.ViewComponents
{
    public class HeaderHomeViewComponent : ViewComponent
    {
        private readonly WebShopContext _webc;
        private readonly IShoppingCart shoppingc;
        private readonly ShoppingCart shop;

        public HeaderHomeViewComponent(WebShopContext web, IShoppingCart _shoppingcart, ShoppingCart _shop)
        {
            shoppingc = _shoppingcart;
            shop = _shop;
            _webc = web;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = shop.Cart();
            try
            {
                var query = await _webc.Categories.Include(u => u.Products).ToListAsync();
                var cat = new List<Category>();
                var BlankCat = new Category() { Id = 0, Name = "All", NameVN = "All" };
                cat.Add(BlankCat);
                var newTable = cat.Union(query);
                ViewBag.Categories = newTable;

            }
            catch { }
            return View(ShoppingCart.Items);
        }
    }
}
