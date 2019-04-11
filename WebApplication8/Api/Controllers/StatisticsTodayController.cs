using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;

namespace WebApplication8.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/StatisticsToday")]
    public class StatisticsTodayController : Controller
    {
        private readonly WebShopContext _db;
        public StatisticsTodayController(WebShopContext wscontext)
        {
            _db = wscontext;
        }
        [HttpGet]
        public IActionResult GetStatisticsToday()
        {
            var now_ = DateTime.Now.Date;
            var data = _db.Orders.Where(u => u.OrderDate.Date == now_ && u.Status > 0).GroupBy(u => u.OrderDate.Date)
                .Select(u => new { Count = u.Count(), Amount = (long)u.Sum(g => g.Amount) });
            return Ok(data);
        }
    }
}