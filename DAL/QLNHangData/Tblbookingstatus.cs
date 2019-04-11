using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblbookingstatus
    {
        public Tblbookingstatus()
        {
            Tblbooking = new HashSet<Tblbooking>();
        }

        public int BokstaId { get; set; }
        public string BokstaName { get; set; }

        public ICollection<Tblbooking> Tblbooking { get; set; }
    }
}
