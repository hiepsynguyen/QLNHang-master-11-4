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
    public class TblrostersController : AdminController
    {
        private readonly QLNhaHangContext _context;

        public TblrostersController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tblrosters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tblroster.ToListAsync());
        }

        // GET: Admin/Tblrosters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblroster = await _context.Tblroster
                .FirstOrDefaultAsync(m => m.ShiId == id);
            if (tblroster == null)
            {
                return NotFound();
            }

            return View(tblroster);
        }

        // GET: Admin/Tblrosters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tblrosters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiId,ShiNm,MaxHr,MinHr,ConH1,AddH1,ConH2,AddH2,BltNm,BltDt,LstNm,LstDt,Tim02,OnnTm,OffTm,NigSh,OnnOt")] Tblroster tblroster)
        {
            if (ModelState.IsValid)
            {
                try {
                    _context.Add(tblroster);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } catch (Exception ex) {
                    Danger(string.Format("<b>Lỗi {0}</b>", ex.Message + ex.InnerException), true);
                }
                
            }
            return View(tblroster);
        }

        // GET: Admin/Tblrosters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var tblroster = new Tblroster();
            try {
                if (id == null)
                {
                    return NotFound();
                }

                tblroster = await _context.Tblroster.FindAsync(id);
                if (tblroster == null)
                {
                    return NotFound();
                }
            } catch (Exception ex) {
                Danger(string.Format("<b>Lỗi {0}</b>", ex.Message + ex.InnerException), true);
            }
            return View(tblroster);
        }

        // POST: Admin/Tblrosters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ShiId,ShiNm,MaxHr,MinHr,ConH1,AddH1,ConH2,AddH2,BltNm,BltDt,LstNm,LstDt,Tim02,OnnTm,OffTm,NigSh,OnnOt")] Tblroster tblroster)
        {

            if (id != tblroster.ShiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblroster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException dbex)
                {
                    if (!TblrosterExists(tblroster.ShiId))
                    {
                        //return NotFound();
                        Danger(string.Format("<b>Lỗi {0}</b>", "Not Found"), true);
                    }
                    else
                    {
                        Danger(string.Format("<b>Lỗi {0}</b>", dbex.Message + dbex.InnerException), true);
                    }
                    return View(tblroster);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblroster);
        }

        // GET: Admin/Tblrosters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblroster = await _context.Tblroster
                .FirstOrDefaultAsync(m => m.ShiId == id);
            if (tblroster == null)
            {
                return NotFound();
            }

            return View(tblroster);
        }

        // POST: Admin/Tblrosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblroster = await _context.Tblroster.FindAsync(id);
            _context.Tblroster.Remove(tblroster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblrosterExists(string id)
        {
            return _context.Tblroster.Any(e => e.ShiId == id);
        }
    }
}
