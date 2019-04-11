using System;
using System.Collections.Generic;

namespace DAL.QLNHangData { 
    public partial class Tblfoodcategory
    {
        public Tblfoodcategory()
        {
            Tblfood = new HashSet<Tblfood>();
        }

        public int FodcaId { get; set; }
        public string FodcaName { get; set; }
        public string Pic { get; set; }
        public bool? Del { get; set; }

        public ICollection<Tblfood> Tblfood { get; set; }
    }
}
