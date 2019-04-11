//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using WebApplication8.TempQLNHData;

//namespace WebApplication8.Controllers
//{
//    public class MonansController : Controller
//    {
//        private readonly QLNhaHangContext _context;

//        public MonansController(QLNhaHangContext context)
//        {
//            _context = context;
//        }

//        // GET: Monans
//        public async Task<IActionResult> Index()
//        {
//            var qLNhaHangContext = _context.Monan.Include(m => m.MaDmmonAnNavigation);
//            return View(await qLNhaHangContext.ToListAsync());
//        }

//        // GET: Monans/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var monan = await _context.Monan
//                .Include(m => m.MaDmmonAnNavigation)
//                .FirstOrDefaultAsync(m => m.MaMonAn == id);
//            if (monan == null)
//            {
//                return NotFound();
//            }

//            return View(monan);
//        }

//        // GET: Monans/Create
//        public IActionResult Create()
//        {
//            ViewData["MaDmmonAn"] = new SelectList(_context.Danhmucmonan, "MaDmmonAn", "MaDmmonAn");
//            return View();
//        }

//        // POST: Monans/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("MaMonAn,TenMonAn,MoTa,Gia,MaDmmonAn,Anh,DanhGia,DaXoa,ConMon")] Monan monan)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(monan);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["MaDmmonAn"] = new SelectList(_context.Danhmucmonan, "MaDmmonAn", "MaDmmonAn", monan.MaDmmonAn);
//            return View(monan);
//        }

//        // GET: Monans/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var monan = await _context.Monan.FindAsync(id);
//            if (monan == null)
//            {
//                return NotFound();
//            }
//            ViewData["MaDmmonAn"] = new SelectList(_context.Danhmucmonan, "MaDmmonAn", "MaDmmonAn", monan.MaDmmonAn);
//            return View(monan);
//        }

//        // POST: Monans/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("MaMonAn,TenMonAn,MoTa,Gia,MaDmmonAn,Anh,DanhGia,DaXoa,ConMon")] Monan monan)
//        {
//            if (id != monan.MaMonAn)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(monan);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!MonanExists(monan.MaMonAn))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["MaDmmonAn"] = new SelectList(_context.Danhmucmonan, "MaDmmonAn", "MaDmmonAn", monan.MaDmmonAn);
//            return View(monan);
//        }

//        // GET: Monans/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var monan = await _context.Monan
//                .Include(m => m.MaDmmonAnNavigation)
//                .FirstOrDefaultAsync(m => m.MaMonAn == id);
//            if (monan == null)
//            {
//                return NotFound();
//            }

//            return View(monan);
//        }

//        // POST: Monans/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var monan = await _context.Monan.FindAsync(id);
//            _context.Monan.Remove(monan);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool MonanExists(int id)
//        {
//            return _context.Monan.Any(e => e.MaMonAn == id);
//        }
//    }
//}
