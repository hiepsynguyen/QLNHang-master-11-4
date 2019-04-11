using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.QLNHangData;

namespace WebApplication8.Areas.Admin.Models.PayrollViewModel
{
    public class DetailsPayrollViewModel
    {
        public Tblpayroll dpayroll { set; get; }
        public string EmpNm { set; get; }
        public string DepNm { set; get; }

    }
}
