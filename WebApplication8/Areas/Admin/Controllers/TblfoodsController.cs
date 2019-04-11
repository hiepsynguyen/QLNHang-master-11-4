using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TblfoodsController : Controller
    {
        private readonly QLNhaHangContext _context;

        public TblfoodsController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tblfoods
        public async Task<IActionResult> Index()
        {
            var qLNhaHangContext = _context.Tblfood.Include(t => t.Fodca);
            return View(await qLNhaHangContext.ToListAsync());
        }

        // GET: Admin/Tblfoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblfood = await _context.Tblfood
                .Include(t => t.Fodca)
                .FirstOrDefaultAsync(m => m.FodId == id);
            if (tblfood == null)
            {
                return NotFound();
            }

            return View(tblfood);
        }

        // GET: Admin/Tblfoods/Create
        public IActionResult Create()
        {
            ViewData["FodcaId"] = new SelectList(_context.Tblfoodcategory, "FodcaId", "FodcaId");
            return View();
        }

        // POST: Admin/Tblfoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FodId,FodName,Description,Price,FodcaId,Pic,Rate,Del,FodAvailable")] Tblfood tblfood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblfood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FodcaId"] = new SelectList(_context.Tblfoodcategory, "FodcaId", "FodcaId", tblfood.FodcaId);
            return View(tblfood);
        }

        // GET: Admin/Tblfoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblfood = await _context.Tblfood.FindAsync(id);
            if (tblfood == null)
            {
                return NotFound();
            }
            ViewData["FodcaId"] = new SelectList(_context.Tblfoodcategory, "FodcaId", "FodcaId", tblfood.FodcaId);
            return View(tblfood);
        }

        // POST: Admin/Tblfoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FodId,FodName,Description,Price,FodcaId,Pic,Rate,Del,FodAvailable")] Tblfood tblfood)
        {
            if (id != tblfood.FodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblfood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblfoodExists(tblfood.FodId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FodcaId"] = new SelectList(_context.Tblfoodcategory, "FodcaId", "FodcaId", tblfood.FodcaId);
            return View(tblfood);
        }

        // GET: Admin/Tblfoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblfood = await _context.Tblfood
                .Include(t => t.Fodca)
                .FirstOrDefaultAsync(m => m.FodId == id);
            if (tblfood == null)
            {
                return NotFound();
            }

            return View(tblfood);
        }

        // POST: Admin/Tblfoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblfood = await _context.Tblfood.FindAsync(id);
            _context.Tblfood.Remove(tblfood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblfoodExists(int id)
        {
            return _context.Tblfood.Any(e => e.FodId == id);
        }
    }
}
