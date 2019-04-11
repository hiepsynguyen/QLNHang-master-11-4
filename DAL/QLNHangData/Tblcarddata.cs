using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblcarddata
    {
        public double? DatTm { get; set; }
        public string EmpId { get; set; }
        public DateTime? SwiDt { get; set; }
        public string UsrNm { get; set; }
        public DateTime CrdDt { get; set; }
        public double CrdTm { get; set; }
        public string CrdNo { get; set; }
        public string ReaNo { get; set; }
        public string StaDr { get; set; }
        public string FilNm { get; set; }
        public bool? YsdBt { get; set; }
    }
}
