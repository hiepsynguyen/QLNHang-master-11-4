using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Admin.Models.LeaveViewModel
{
    public class LeaveOpViewModel
    {
        public UCLeaveViewModel ucLeave { set; get; }
        public string EmpId { set; get; }
        public string UserLogin { set; get; }
        public string InhDt { set; get; }
        public int SeqNo { set; get; }

    }
}
