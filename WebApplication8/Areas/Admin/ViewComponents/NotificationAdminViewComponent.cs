using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;

namespace WebApplication8.Areas.Admin.ViewComponents
{
    public class NotificationAdminViewComponent:ViewComponent
    {
        private readonly WebShopContext _webc;
        public NotificationAdminViewComponent(WebShopContext webc) {
            _webc = webc;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = await _webc.Categories.Include(u => u.Products).ToListAsync();
            // return PartialView("Partials/_Category", model);
            return View();
        }
    }
}
