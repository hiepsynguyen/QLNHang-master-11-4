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
    public class OrderDetailViewComponent : ViewComponent
    {
        private readonly WebShopContext _webc;
        private readonly IShoppingCart shoppingc;
        private readonly ShoppingCart shop;
        public OrderDetailViewComponent(IShoppingCart _shoppingcart, ShoppingCart _shop, WebShopContext web)
        {
            shoppingc = _shoppingcart;
            shop = _shop;
            _webc = web;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = await _webc.Categories.Include(u => u.Products).ToListAsync();
            return View(ShoppingCart.Items);
        }

    }
}
