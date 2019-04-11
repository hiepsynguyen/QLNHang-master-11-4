using System;
using System.Collections.Generic;

namespace DAL.QLNHangData
{
    public partial class Tblusertype
    {
        public Tblusertype()
        {
            Tbluser = new HashSet<Tbluser>();
        }

        public int UsId { get; set; }
        public string UsName { get; set; }

        public ICollection<Tbluser> Tbluser { get; set; }
    }
}
