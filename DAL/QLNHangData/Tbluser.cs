using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tbluser
    {
        public Tbluser()
        {
            Tblbooking = new HashSet<Tblbooking>();
        }

        public string UsLogin { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pic { get; set; }
        public bool? Del { get; set; }
        public int? UsId { get; set; }

        public Tblusertype Us { get; set; }
        public ICollection<Tblbooking> Tblbooking { get; set; }
    }
}
