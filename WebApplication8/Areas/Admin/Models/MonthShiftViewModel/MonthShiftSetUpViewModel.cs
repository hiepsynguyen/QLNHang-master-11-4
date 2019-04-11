using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Admin.Models.MonthShiftViewModel
{
    public class MonthShiftSetUpViewModel
    {
        public string SHI_ID { set; get; }
        public DateTime STR_DT { set; get; }
        public DateTime END_DT { set; get; }
        public bool SequenceShift { set; get; }
        public bool SatOff { set; get; }
        public bool SunOff { set; get; }
    }
}
