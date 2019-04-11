using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Admin.Models.MonthAttendanceViewModels
{
    public class MonthAttendanceSearchViewModel
    {
        public string EmpId { set; get; }
        public DateRangeViewModel DateRange { set; get; }
        public string DepId { set; get; }
    }
}
