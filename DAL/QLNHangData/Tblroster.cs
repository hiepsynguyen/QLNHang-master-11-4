using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.QLNHangData
{
    public partial class Tblroster
    {
        [Required]
        [DisplayName("Mã ca")]
        public string ShiId { get; set; }
        [Required]
        [DisplayName("Tên ca")]
        public string ShiNm { get; set; }
        public double? MaxHr { get; set; }
        public double? MinHr { get; set; }
        public double? ConH1 { get; set; }
        public double? AddH1 { get; set; }
        public double? ConH2 { get; set; }
        public double? AddH2 { get; set; }
        public string BltNm { get; set; }
        public DateTime? BltDt { get; set; }
        public string LstNm { get; set; }
        public DateTime? LstDt { get; set; }
        public bool? Tim02 { get; set; }
        public double? OnnTm { get; set; }
        public double? OffTm { get; set; }
        public bool? NigSh { get; set; }
        public double? OnnOt { get; set; }
    }
}
