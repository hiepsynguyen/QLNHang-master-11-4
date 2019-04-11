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
    [Route("api/Statistics")]
    public class StatisticsController : Controller
    {
        private readonly WebShopContext _db;
        public StatisticsController(WebShopContext _wscontext) {
            _db = _wscontext;
        }

        [HttpGet]
        public IActionResult GetStatisticsToday() {
            var now_ = DateTime.Now;
            var data = _db.Orders.Where(u => u.OrderDate == now_).GroupBy(u => u.OrderDate)
                .Select(u => new { Count = u.Count(), Amount = u.Sum(g => g.Amount) });
            return Ok(data);
        }
    }
}