using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblbookdetail
    {
        public int BokdetId { get; set; }
        public int? BokId { get; set; }
        public int? FodId { get; set; }
        public int? Quantity { get; set; }

        public Tblbooking Bok { get; set; }
        public Tblfood Fod { get; set; }
    }
}
