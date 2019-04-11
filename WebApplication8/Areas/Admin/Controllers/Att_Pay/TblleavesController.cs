using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Areas.Admin.Models.LeaveViewModel;
using WebApplication8.Helper;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TblleavesController : Controller
    {
        private readonly QLNhaHangContext _context;

        public TblleavesController(QLNhaHangContext context)
        {
            _context = context;
        }

        // GET: Admin/Tblleaves
        public async Task<IActionResult> Index()
        {
            ViewData["list_emp"] = await _context.Tblemployee.ToListAsync();
            return View();
        }

        public async Task<IActionResult> GetListLeaveByEmpId(string EmpId)
        {
            var l = await _context.Tblleave.Where(x => x.EmpId == EmpId).ToListAsync();
            return PartialView(l);
        }

        // GET: Admin/Tblleaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblleave = await _context.Tblleave
                .FirstOrDefaultAsync(m => m.SeqNo == id);
            if (tblleave == null)
            {
                return NotFound();
            }

            return View(tblleave);
        }

        // GET: Admin/Tblleaves/Create
        public async Task<IActionResult> LeaveInsert(string EmpId)
        {
            var emp_ = await _context.Tblemployee.Where(x => x.EmpId == EmpId).FirstOrDefaultAsync();
            ViewData["emp_nm"] = emp_.EmpNm;
            ViewData["emp_inh_dt"] = emp_.InhDt;
            ViewData["l_type_leave"] = await _context.Tbltypeleave.ToListAsync();
            ViewData["l_type_shift"] = await _context.Tblroster.ToListAsync();
            var m = new LeaveOpViewModel() { ucLeave = new UCLeaveViewModel() { STR_DT = DateTime.Now, END_DT = DateTime.Now}, EmpId = EmpId };
            return View(m);
        }

        public async Task<IActionResult> LeaveUpdate(string EmpId,int SeqNo)
        {
            var emp_ = await _context.Tblemployee.Where(x => x.EmpId == EmpId).FirstOrDefaultAsync();
            var leave = await _context.Tblleave.Where(x=>x.EmpId == EmpId && x.SeqNo == SeqNo).FirstOrDefaultAsync();
            ViewData["emp_nm"] = emp_.EmpNm;
            ViewData["emp_inh_dt"] = emp_.InhDt;
            ViewData["l_type_leave"] = await _context.Tbltypeleave.ToListAsync();
            ViewData["l_type_shift"] = await _context.Tblroster.ToListAsync();
            var m = new LeaveOpViewModel() { ucLeave = new UCLeaveViewModel(leave), EmpId = EmpId, SeqNo = SeqNo };
            return View(m);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LeaveInsert(LeaveOpViewModel model)
        {
            //var m = new LeaveOpViewModel() { ucLeave = new UCLeaveViewModel(), EmpId = EmpId };
            //return View(m);
            var leave = new LeaveHelper(model);
            leave.Leave_Insert();
            return Json(leave);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LeaveUpdate(LeaveOpViewModel model)
        {
            //var m = new LeaveOpViewModel() { ucLeave = new UCLeaveViewModel(), EmpId = EmpId };
            //return View(m);
            var leave = new LeaveHelper(model);
            leave.Leave_Update();
            return Json(leave);
        }

        [HttpPost]
        public IActionResult LeaveChangeDate(LeaveOpViewModel model) {
            var leave = new LeaveHelper(model);
            leave.dt1_ValueChanged();
            return Json(leave);
        }

        [HttpPost]
        public IActionResult LeaveChangeShift(LeaveOpViewModel model)
        {
            var leave = new LeaveHelper(model);
            leave.cb1_SelectedValueChanged();
            return Json(leave);
        }

        [HttpPost]
        public IActionResult LeaveChangeTime(LeaveOpViewModel model)
        {
            var leave = new LeaveHelper(model);
            leave.dt3_ValueChanged();
            return Json(leave);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveDelete(string EmpId, int SeqNo)
        {
            //var m = new LeaveOpViewModel() { ucLeave = new UCLeaveViewModel(), EmpId = EmpId };
            //return View(m);
            //var leave = new LeaveHelper(model);
            //leave.Leave_Insert();
            //return Json(leave);
            var leave = new LeaveHelper();
            var l = await _context.Tblleave.Where(x => x.EmpId == EmpId && x.SeqNo == SeqNo).FirstOrDefaultAsync();
            leave.LeaveDelete(l);
            return Json(leave);
        }



        // POST: Admin/Tblleaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeqNo,EmpId,StrDt,EndDt,HouDy,StrTm,EndTm,HouTt,LeaId,DayTt,DayBt,NotDr,BltNm,BltDt,LstNm,LstDt")] Tblleave tblleave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblleave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblleave);
        }

        // GET: Admin/Tblleaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblleave = await _context.Tblleave.FindAsync(id);
            if (tblleave == null)
            {
                return NotFound();
            }
            return View(tblleave);
        }

        // POST: Admin/Tblleaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeqNo,EmpId,StrDt,EndDt,HouDy,StrTm,EndTm,HouTt,LeaId,DayTt,DayBt,NotDr,BltNm,BltDt,LstNm,LstDt")] Tblleave tblleave)
        {
            if (id != tblleave.SeqNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblleave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblleaveExists(tblleave.SeqNo))
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
            return View(tblleave);
        }

        // GET: Admin/Tblleaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblleave = await _context.Tblleave
                .FirstOrDefaultAsync(m => m.SeqNo == id);
            if (tblleave == null)
            {
                return NotFound();
            }

            return View(tblleave);
        }

        // POST: Admin/Tblleaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblleave = await _context.Tblleave.FindAsync(id);
            _context.Tblleave.Remove(tblleave);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblleaveExists(int id)
        {
            return _context.Tblleave.Any(e => e.SeqNo == id);
        }
    }
}
