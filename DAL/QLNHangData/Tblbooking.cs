using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblbooking
    {
        public Tblbooking()
        {
            Tblbookdetail = new HashSet<Tblbookdetail>();
        }

        public int BokId { get; set; }
        public int? TbfodId { get; set; }
        public string UsLogin { get; set; }
        public DateTime? BokDate { get; set; }
        public DateTime? BoktblDate { get; set; }
        public int? BokstaId { get; set; }
        public double? TotalPrice { get; set; }

        public Tbltablefood Bok { get; set; }
        public Tblbookingstatus Boksta { get; set; }
        public Tbluser UsLoginNavigation { get; set; }
        public ICollection<Tblbookdetail> Tblbookdetail { get; set; }
    }
}
