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
    public class SpecialHomeViewComponent : ViewComponent
    {
        private readonly WebShopContext _webc;
        private readonly IShoppingCart shoppingc;
        private readonly ShoppingCart shop;

        public SpecialHomeViewComponent(WebShopContext web, IShoppingCart _shoppingcart, ShoppingCart _shop)
        {
            shoppingc = _shoppingcart;
            shop = _shop;
            _webc = web;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _webc.Products.Include(u => u.Category).Include(u => u.Supplier).Where(p => p.Special == true).Take(10).ToListAsync();

            return View(model);
        }

    }
}
