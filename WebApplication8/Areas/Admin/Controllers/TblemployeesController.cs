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
    public class TblemployeesController : Controller
    {
        private readonly QLNhaHangContext _context;

        public TblemployeesController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tblemployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tblemployee.ToListAsync());
        }

        // GET: Admin/Tblemployees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblemployee = await _context.Tblemployee
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (tblemployee == null)
            {
                return NotFound();
            }

            return View(tblemployee);
        }

        // GET: Admin/Tblemployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tblemployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpI1,EmpNm,EmpN1,MstDr,BirDt,SexBt,MarBt,DepId,CouId,CrdNo,PosId,AddDr,AddD1,InhDt,CrdId,CrdDt,CrdLc,CitId,RacNm,NatCo,EduId,ProId,GraId,TelNo,TypId,AccNo,AccNm,BnkNm,RelDr,NewBt,MeaBt,RemDr,AttBt,SalBt,VacBt,DelBt,GrtId,GrpId,LevId,LckBt,BhxBt,DirBt,BltNm,BltDt,LstNm,LstDt,SenDt,RemD2,FirDt")] Tblemployee tblemployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblemployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblemployee);
        }

        // GET: Admin/Tblemployees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblemployee = await _context.Tblemployee.FindAsync(id);
            if (tblemployee == null)
            {
                return NotFound();
            }
            return View(tblemployee);
        }

        // POST: Admin/Tblemployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmpId,EmpI1,EmpNm,EmpN1,MstDr,BirDt,SexBt,MarBt,DepId,CouId,CrdNo,PosId,AddDr,AddD1,InhDt,CrdId,CrdDt,CrdLc,CitId,RacNm,NatCo,EduId,ProId,GraId,TelNo,TypId,AccNo,AccNm,BnkNm,RelDr,NewBt,MeaBt,RemDr,AttBt,SalBt,VacBt,DelBt,GrtId,GrpId,LevId,LckBt,BhxBt,DirBt,BltNm,BltDt,LstNm,LstDt,SenDt,RemD2,FirDt")] Tblemployee tblemployee)
        {
            if (id != tblemployee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblemployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblemployeeExists(tblemployee.EmpId))
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
            return View(tblemployee);
        }

        // GET: Admin/Tblemployees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblemployee = await _context.Tblemployee
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (tblemployee == null)
            {
                return NotFound();
            }

            return View(tblemployee);
        }

        // POST: Admin/Tblemployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblemployee = await _context.Tblemployee.FindAsync(id);
            _context.Tblemployee.Remove(tblemployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblemployeeExists(string id)
        {
            return _context.Tblemployee.Any(e => e.EmpId == id);
        }
    }
}
