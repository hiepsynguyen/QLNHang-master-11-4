using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;
using WebApplication8.Models.ShoppingCart;

namespace WebApplication8.ViewComponents
{
    public class CategoryHomeViewComponent : ViewComponent
    {
        private readonly WebShopContext _webc;
        private readonly IShoppingCart shoppingc;
        private readonly ShoppingCart shop;

        public CategoryHomeViewComponent(WebShopContext web, IShoppingCart _shoppingcart, ShoppingCart _shop)
        {
            shoppingc = _shoppingcart;
            shop = _shop;
            _webc = web;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _webc.Categories.Include(u => u.Products).ToListAsync();
            // return PartialView("Partials/_Category", model);
            return View(model);
        }
    }
}
