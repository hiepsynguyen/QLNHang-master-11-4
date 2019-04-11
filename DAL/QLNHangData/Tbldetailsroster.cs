using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DAL.QLNHangData
{
    public partial class Tbldetailsroster
    {
        [DisplayName("Mã ca")]
        public string ShiId { get; set; }
        public int SeqN1 { get; set; }

        [DisplayName("Số thứ tự hiển thị")]
        public string SeqNo { get; set; }
        [DisplayName("Giờ vào")]
        public double? OnnTm { get; set; }
        public string OnnRd { get; set; }
        public bool? OnnBt { get; set; }
        [DisplayName("Giờ ra")]
        public double? OffTm { get; set; }
        public string OffRd { get; set; }
        public bool? OffBt { get; set; }
        [DisplayName("Loại ca")]
        public string TypId { get; set; }
        public double? MinSt { get; set; }
        [DisplayName("Số giờ làm")]
        public double? WrkHr { get; set; }
        [DisplayName("Tính trễ sớm")]
        public bool? LatBt { get; set; }
        public string BltNm { get; set; }
        public DateTime? BltDt { get; set; }
        public string LstNm { get; set; }
        public DateTime? LstDt { get; set; }
        public double? ManIn { get; set; }
        public double? ManOu { get; set; }
    }
}
