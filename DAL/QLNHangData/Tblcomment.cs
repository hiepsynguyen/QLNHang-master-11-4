using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblcomment
    {
        public int CmtId { get; set; }
        public string CmtContent { get; set; }
        public int? Rate { get; set; }
        public string Usercmt { get; set; }
        public DateTime? Time { get; set; }
        public bool? Del { get; set; }
        public int? FodId { get; set; }

        public Tblfood Fod { get; set; }
    }
}
