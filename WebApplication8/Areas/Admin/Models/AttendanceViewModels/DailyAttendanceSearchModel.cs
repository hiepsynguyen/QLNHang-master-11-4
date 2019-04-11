using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Admin.Models.AttendanceViewModels
{
    public class DailyAttendanceSearchModel
    {
        public string EmpId { set; get; }
        public DateRangeViewModel DateRange { set; get; }
        public string DepId { set; get; }
    }
}
