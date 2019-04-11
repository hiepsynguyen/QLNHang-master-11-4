using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblfood
    {
        public Tblfood()
        {
            Tblbookdetail = new HashSet<Tblbookdetail>();
            Tblcomment = new HashSet<Tblcomment>();
        }

        public int FodId { get; set; }
        public string FodName { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? FodcaId { get; set; }
        public string Pic { get; set; }
        public int? Rate { get; set; }
        public bool? Del { get; set; }
        public bool? FodAvailable { get; set; }

        public Tblfoodcategory Fodca { get; set; }
        public ICollection<Tblbookdetail> Tblbookdetail { get; set; }
        public ICollection<Tblcomment> Tblcomment { get; set; }
    }
}
