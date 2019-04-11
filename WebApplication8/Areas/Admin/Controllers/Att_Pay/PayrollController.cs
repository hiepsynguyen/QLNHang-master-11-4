using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Areas.Admin.Models.PayrollViewModel;
using WebApplication8.Helper;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Controllers.Att_Pay
{
    [Area("Admin")]
    public class PayrollController : AdminController
    {
        QLNhaHangContext _db = new QLNhaHangContext();
        public IActionResult Index(PayrollSearchViewModel searchModel)
        {
            if (searchModel.DateRange == null)
            {
                searchModel.DateRange = new Areas.Admin.Models.DateRangeViewModel()
                {
                    StrDate = DateTime.Now.AddDays(-7),
                    EndDate = DateTime.Now
                };

            }

            searchModel.EmpId = searchModel.EmpId == null ? "" : searchModel.EmpId;
            var list = (from pay in _db.Tblpayroll
                        join e in _db.Tblemployee
             on pay.EmpId equals e.EmpId
                        join d in _db.Tbldeparment
 on e.DepId equals d.DepId
                        where pay.YyyMm == searchModel.DateRange.StrDate.ToString("yyyyMM")
                        && e.EmpId.Contains(searchModel.EmpId)
                        select new DetailsPayrollViewModel() { dpayroll = pay, DepNm = d.DepNm, EmpNm = e.EmpNm }).ToList();
            ViewData["list_details"] = list;
            return View(searchModel);
        }

        public IActionResult Cal(PayrollCalViewModel payrollModel) {

            return View(payrollModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalPost(PayrollCalViewModel payrollModel)
        {
            string err = "";
            PayrollCalHelper proll = null;
            try {
                proll = new PayrollCalHelper(payrollModel.dt1, payrollModel.dt2, payrollModel.dt3, payrollModel.crt);
                proll.CalFinalSalary();
            } catch (Exception ex) {
                err += ex.Message + " - " + ex.StackTrace;
            }
            return Json(err + proll.err);
        }
    }
}