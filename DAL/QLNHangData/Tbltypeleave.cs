using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tbltypeleave
    {
        public string LeaId { get; set; }
        public string SeqNo { get; set; }
        public string ColNm { get; set; }
        public string LeaNm { get; set; }
        public string ShrNm { get; set; }
        public int? DayMm { get; set; }
        public int? DayYy { get; set; }
        public int? DayQt { get; set; }
        public int? DayTm { get; set; }
        public bool? SalCk { get; set; }
        public bool? HolBt { get; set; }
    }
}
