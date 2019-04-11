using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Models.MonthAttendanceViewModels
{
    public class MonthlyAttendanceViewModel
    {
        public Tblmonthattendance matt { set; get; }
        public string Emp_nm { set; get; }
        public string Dep_nm { set; get; }

    }
}
