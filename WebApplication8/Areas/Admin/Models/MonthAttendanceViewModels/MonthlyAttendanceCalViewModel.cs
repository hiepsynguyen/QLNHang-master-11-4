using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Areas.Admin.Models.CommonViewModel;

namespace WebApplication8.Areas.Admin.Models.MonthAttendanceViewModels
{
    public class MonthlyAttendanceCalViewModel
    {
        public CrtConditionViewModel crt1 { set; get; }
        
        public DateTime dt3 { set; get; }
        public DateTime dt1 { set; get; }
        public DateTime dt2 { set; get; }
    }
}
