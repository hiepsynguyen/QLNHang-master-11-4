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
    public class TbltablecategoriesController : Controller
    {
        private readonly QLNhaHangContext _context;

        public TbltablecategoriesController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tbltablecategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbltablecategory.ToListAsync());
        }

        // GET: Admin/Tbltablecategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbltablecategory = await _context.Tbltablecategory
                .FirstOrDefaultAsync(m => m.TabcaId == id);
            if (tbltablecategory == null)
            {
                return NotFound();
            }

            return View(tbltablecategory);
        }

        // GET: Admin/Tbltablecategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tbltablecategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TabcaId,TabcaName,Pic,Del,Description")] Tbltablecategory tbltablecategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbltablecategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbltablecategory);
        }

        // GET: Admin/Tbltablecategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbltablecategory = await _context.Tbltablecategory.FindAsync(id);
            if (tbltablecategory == null)
            {
                return NotFound();
            }
            return View(tbltablecategory);
        }

        // POST: Admin/Tbltablecategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TabcaId,TabcaName,Pic,Del,Description")] Tbltablecategory tbltablecategory)
        {
            if (id != tbltablecategory.TabcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbltablecategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbltablecategoryExists(tbltablecategory.TabcaId))
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
            return View(tbltablecategory);
        }

        // GET: Admin/Tbltablecategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbltablecategory = await _context.Tbltablecategory
                .FirstOrDefaultAsync(m => m.TabcaId == id);
            if (tbltablecategory == null)
            {
                return NotFound();
            }

            return View(tbltablecategory);
        }

        // POST: Admin/Tbltablecategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbltablecategory = await _context.Tbltablecategory.FindAsync(id);
            _context.Tbltablecategory.Remove(tbltablecategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbltablecategoryExists(int id)
        {
            return _context.Tbltablecategory.Any(e => e.TabcaId == id);
        }
    }
}
