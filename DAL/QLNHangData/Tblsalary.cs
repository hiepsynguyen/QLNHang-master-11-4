using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblsalary
    {
        public string EmpId { get; set; }
        public int SeqNo { get; set; }
        public DateTime? ChaDt { get; set; }
        public string NotDr { get; set; }
        public string BltNm { get; set; }
        public DateTime? BltDt { get; set; }
        public string LstNm { get; set; }
        public DateTime? LstDt { get; set; }
        public bool? DonAp { get; set; }
        public string ReaDr { get; set; }
        public double? Lcb { get; set; }
    }
}
