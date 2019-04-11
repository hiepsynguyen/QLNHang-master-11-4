using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Areas.Admin.Models.BasicSalaryViewModel;
using WebApplication8.Areas.Admin.Models.CommonViewModel;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Controllers.Att_Pay
{
    [Area("Admin")]
    public class TblsalariesController : Controller
    {
        private readonly QLNhaHangContext _context;

        public TblsalariesController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tblsalaries
        public async Task<IActionResult> Index(EmployeeSearchViewModel searchModel)
        {
            var _l = await (from e in _context.Tblemployee
                      join d in _context.Tbldeparment on e.DepId equals d.DepId
                      where e.EmpId.Contains(searchModel.EmpId)
&& e.DepId.Contains(searchModel.DepId == null ? "": searchModel.DepId)
                      select new BasicEmployeeViewModel() { EmpId = e.EmpId, DepNm = d.DepNm, EmpNm = e.EmpNm }).ToListAsync();
                     ;
            ViewData["list_result"] = _l;
            return View();
        }

        // GET: Admin/Tblsalaries/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblsalary = await _context.Tblsalary
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (tblsalary == null)
            {
                return NotFound();
            }

            return View(tblsalary);
        }

        // GET: Admin/Tblsalaries/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateEmpId(string EmpId, int SeqNo)
        {
            var _e = _context.Tblsalary.Where(x => x.EmpId == EmpId).OrderByDescending(x=>x.SeqNo).FirstOrDefault();
            SeqNo = _e == null ? 1 : _e.SeqNo + 1;
            var _m = new Tblsalary() { EmpId = EmpId, SeqNo = SeqNo };
            return View("Create", _m);
        }



        // POST: Admin/Tblsalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,SeqNo,ChaDt,Lcb")] Tblsalary tblsalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblsalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblsalary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost([Bind("EmpId,SeqNo,ChaDt,NotDr,BltNm,BltDt,LstNm,LstDt,DonAp,ReaDr,Lcb")] Tblsalary tblsalary)
        {
            try {
                if (ModelState.IsValid)
                {
                    _context.Add(tblsalary);
                    await _context.SaveChangesAsync();
                    return Json("");
                }
                return Json("Not valid Model");
            } catch (Exception ex) {
                return Json(ex.Message + " - " + ex.StackTrace);
            }
        }

        // GET: Admin/Tblsalaries/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblsalary = await _context.Tblsalary.FindAsync(id);
            if (tblsalary == null)
            {
                return NotFound();
            }
            return View(tblsalary);
        }

        public async Task<IActionResult> EditEmpId(string EmpId,int SeqNo)
        {
            if (EmpId == null)
            {
                return NotFound();
            }

            var tblsalary = await _context.Tblsalary.SingleOrDefaultAsync(x=>x.EmpId == EmpId && x.SeqNo == SeqNo);
            if (tblsalary == null)
            {
                return NotFound();
            }
            return View("Edit", tblsalary);
        }

        public async Task<IActionResult> GetBasicSalaryByEmpId(string EmpId)
        {

            ViewData["list_result"] = await _context.Tblsalary.Where(x => x.EmpId == EmpId).OrderBy(x => x.SeqNo).ToListAsync();
            return PartialView();
        }

        // POST: Admin/Tblsalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmpId,SeqNo,ChaDt,NotDr,BltNm,BltDt,LstNm,LstDt,DonAp,ReaDr,Lcb")] Tblsalary tblsalary)
        {
            if (id != tblsalary.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblsalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblsalaryExists(tblsalary.EmpId))
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
            return View(tblsalary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(string id, [Bind("EmpId,SeqNo,ChaDt,Lcb")] Tblsalary tblsalary)
        {
            if (id != tblsalary.EmpId)
            {
                return Json("Not Found");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblsalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException dbex)
                {
                    if (!TblsalaryExists(tblsalary.EmpId))
                    {
                        return Json("Not Found");
                    }
                    else
                    {
                        return Json(dbex.Message + " - " + dbex.StackTrace);
                    }
                }
                catch (Exception ex) {
                    return Json(ex.Message + " - " + ex.StackTrace);
                }
                return Json("");
            }
            return Json("Not valid Model");
        }

        // GET: Admin/Tblsalaries/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblsalary = await _context.Tblsalary
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (tblsalary == null)
            {
                return NotFound();
            }

            return View(tblsalary);
        }

        // POST: Admin/Tblsalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblsalary = await _context.Tblsalary.FindAsync(id);
            _context.Tblsalary.Remove(tblsalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblsalaryExists(string id)
        {
            return _context.Tblsalary.Any(e => e.EmpId == id);
        }
    }
}
