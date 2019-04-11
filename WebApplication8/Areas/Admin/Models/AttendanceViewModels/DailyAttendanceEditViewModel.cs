using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Admin.Models.AttendanceViewModels
{
    public class DailyAttendanceEditViewModel
    {
        public string EMP_ID { set; get; }
        public DateTime ATT_DT { set; get; }
        public string ONN_01 { set; get; }
        public string OFF_01 { set; get; }
        public string SHI_ID { set; get; }
        public string NOT_DR { set; get; }
    }
}
