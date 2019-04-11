using DAL.QLNHangData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication8.Areas.Admin.Models.AttendanceViewModels
{
    public class DailyAttendanceListView
    {
        public Tbldetailsattendance detailsatt { set; get; }
        public string name_emp { set; get; }
        public string dep_nm { set; get; }
        public string shi_nm { set; get; }
    }
}
