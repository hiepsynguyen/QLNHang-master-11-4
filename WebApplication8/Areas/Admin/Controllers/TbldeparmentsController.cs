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
    public class TbldeparmentsController : Controller
    {
        private readonly QLNhaHangContext _context;

        public TbldeparmentsController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tbldeparments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbldeparment.ToListAsync());
        }

        // GET: Admin/Tbldeparments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldeparment = await _context.Tbldeparment
                .FirstOrDefaultAsync(m => m.DepId == id);
            if (tbldeparment == null)
            {
                return NotFound();
            }

            return View(tbldeparment);
        }

        // GET: Admin/Tbldeparments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tbldeparments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepId,DepNm,DepN1,DepHg,ColNo,PeoTt,SegHr,RouMn,RemDr,SeqNo,DirDp")] Tbldeparment tbldeparment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbldeparment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbldeparment);
        }

        // GET: Admin/Tbldeparments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldeparment = await _context.Tbldeparment.FindAsync(id);
            if (tbldeparment == null)
            {
                return NotFound();
            }
            return View(tbldeparment);
        }

        // POST: Admin/Tbldeparments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DepId,DepNm,DepN1,DepHg,ColNo,PeoTt,SegHr,RouMn,RemDr,SeqNo,DirDp")] Tbldeparment tbldeparment)
        {
            if (id != tbldeparment.DepId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbldeparment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbldeparmentExists(tbldeparment.DepId))
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
            return View(tbldeparment);
        }

        // GET: Admin/Tbldeparments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldeparment = await _context.Tbldeparment
                .FirstOrDefaultAsync(m => m.DepId == id);
            if (tbldeparment == null)
            {
                return NotFound();
            }

            return View(tbldeparment);
        }

        // POST: Admin/Tbldeparments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tbldeparment = await _context.Tbldeparment.FindAsync(id);
            _context.Tbldeparment.Remove(tbldeparment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbldeparmentExists(string id)
        {
            return _context.Tbldeparment.Any(e => e.DepId == id);
        }
    }
}
