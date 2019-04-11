using System;
using System.Collections.Generic;

namespace DAL.QLNHangData { 
    public partial class Tbltablefood
    {
        public int TbfodId { get; set; }
        public string TbfodName { get; set; }
        public int? TabcaId { get; set; }
        public string Pic { get; set; }
        public bool? Del { get; set; }
        public bool? TbfodAvi { get; set; }

        public Tbltablecategory Tabca { get; set; }
        public Tblbooking Tblbooking { get; set; }
    }
}
