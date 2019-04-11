using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblleave
    {
        public int SeqNo { get; set; }
        public string EmpId { get; set; }
        public DateTime? StrDt { get; set; }
        public DateTime? EndDt { get; set; }
        public double? HouDy { get; set; }
        public int? StrTm { get; set; }
        public int? EndTm { get; set; }
        public double? HouTt { get; set; }
        public string LeaId { get; set; }
        public double? DayTt { get; set; }
        public bool? DayBt { get; set; }
        public string NotDr { get; set; }
        public string BltNm { get; set; }
        public DateTime? BltDt { get; set; }
        public string LstNm { get; set; }
        public DateTime? LstDt { get; set; }
    }
}
