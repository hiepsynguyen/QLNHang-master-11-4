using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Areas.Admin.Models.MonthAttendanceViewModels;
using WebApplication8.Helper;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Controllers.Att_Pay
{
    [Area("Admin")]
    public class AttMonthAddUpController : Controller
    {
        QLNhaHangContext _db = new QLNhaHangContext();
        public IActionResult Index(MonthAttendanceSearchViewModel modelSearch)
        {
            if (modelSearch.DateRange == null)
            {
                modelSearch.DateRange = new Areas.Admin.Models.DateRangeViewModel()
                {
                    StrDate = DateTime.Now.AddDays(-7),
                    EndDate = DateTime.Now
                };

            }
            modelSearch.EmpId = modelSearch.EmpId == null ? "" : modelSearch.EmpId;
            var list = (from matt in _db.Tblmonthattendance
                        join e in _db.Tblemployee
             on matt.EmpId equals e.EmpId
                        join d in _db.Tbldeparment
 on e.DepId equals d.DepId
                        where matt.YyyMm == modelSearch.DateRange.StrDate.ToString("yyyyMM")
                        && e.EmpId.Contains(modelSearch.EmpId)
                        select new MonthlyAttendanceViewModel() { matt = matt, Dep_nm = d.DepNm, Emp_nm = e.EmpNm }).ToList();
            ViewData["list_details"] = list;
            return View(modelSearch);
        }

        public IActionResult Cal(MonthlyAttendanceCalViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult CalPost(MonthlyAttendanceCalViewModel model)
        {
            AttMonthAddUpCalHelper _m = new AttMonthAddUpCalHelper(model.dt1, model.dt2, model.dt3, model.crt1);
            _m.cmd_mon_cal();
            return Json(_m.err);
        }

    }
}