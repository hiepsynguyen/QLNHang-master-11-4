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
    public class TbldetailsrostersController : Controller
    {
        private readonly QLNhaHangContext _context;

        public TbldetailsrostersController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tbldetailsrosters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbldetailsroster.ToListAsync());
        }

        // GET: Admin/Tbldetailsrosters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldetailsroster = await _context.Tbldetailsroster
                .FirstOrDefaultAsync(m => m.ShiId == id);
            if (tbldetailsroster == null)
            {
                return NotFound();
            }

            return View(tbldetailsroster);
        }

        // GET: Admin/Tbldetailsrosters/Create
        public IActionResult Create(string ShiId)
        {
            var _m = new Tbldetailsroster() {ShiId = ShiId };
            return View(_m);
        }

        // POST: Admin/Tbldetailsrosters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiId,SeqN1,SeqNo,OnnTm,OnnRd,OnnBt,OffTm,OffRd,OffBt,TypId,MinSt,WrkHr,LatBt,BltNm,BltDt,LstNm,LstDt,ManIn,ManOu")] Tbldetailsroster tbldetailsroster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbldetailsroster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbldetailsroster);
        }

        // GET: Admin/Tbldetailsrosters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldetailsroster = await _context.Tbldetailsroster.FindAsync(id);
            if (tbldetailsroster == null)
            {
                return NotFound();
            }
            return View(tbldetailsroster);
        }

        // POST: Admin/Tbldetailsrosters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ShiId,SeqN1,SeqNo,OnnTm,OnnRd,OnnBt,OffTm,OffRd,OffBt,TypId,MinSt,WrkHr,LatBt,BltNm,BltDt,LstNm,LstDt,ManIn,ManOu")] Tbldetailsroster tbldetailsroster)
        {
            if (id != tbldetailsroster.ShiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbldetailsroster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbldetailsrosterExists(tbldetailsroster.ShiId))
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
            return View(tbldetailsroster);
        }

        // GET: Admin/Tbldetailsrosters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldetailsroster = await _context.Tbldetailsroster
                .FirstOrDefaultAsync(m => m.ShiId == id);
            if (tbldetailsroster == null)
            {
                return NotFound();
            }

            return View(tbldetailsroster);
        }

        public async Task<IActionResult> GetListDetailsRosterByRoster(string ShiId) {
            var _l = await _context.Tbldetailsroster.Where(x => x.ShiId == ShiId).ToListAsync();
            return PartialView(_l);
        }

        // POST: Admin/Tbldetailsrosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tbldetailsroster = await _context.Tbldetailsroster.FindAsync(id);
            _context.Tbldetailsroster.Remove(tbldetailsroster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbldetailsrosterExists(string id)
        {
            return _context.Tbldetailsroster.Any(e => e.ShiId == id);
        }
    }
}
