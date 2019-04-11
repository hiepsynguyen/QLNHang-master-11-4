using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tbldeparment
    {
        public string DepId { get; set; }
        public string DepNm { get; set; }
        public string DepN1 { get; set; }
        public string DepHg { get; set; }
        public string ColNo { get; set; }
        public int? PeoTt { get; set; }
        public int? SegHr { get; set; }
        public int? RouMn { get; set; }
        public string RemDr { get; set; }
        public int? SeqNo { get; set; }
        public bool? DirDp { get; set; }
    }
}
