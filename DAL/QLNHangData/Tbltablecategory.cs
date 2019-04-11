using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tbltablecategory
    {
        public Tbltablecategory()
        {
            Tbltablefood = new HashSet<Tbltablefood>();
        }

        public int TabcaId { get; set; }
        public string TabcaName { get; set; }
        public string Pic { get; set; }
        public bool? Del { get; set; }
        public string Description { get; set; }

        public ICollection<Tbltablefood> Tbltablefood { get; set; }
    }
}
