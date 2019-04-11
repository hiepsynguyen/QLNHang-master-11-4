using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.WebShop
{
    public partial  class ImportStock
    {
        public int ID { set; get; }
        public int IdStock { set; get; }
        public DateTime CreateDate { set; get; }
        public string Notes { set; get; }
        public int PaymentMt { set; get; }
        public double Discount { set; get; }
        public double Total { set; get; }
        public double Payed { set; get; }
        public double Lack { set; get; }
        public int Status { set; get; }
        public DateTime Updated { set; get; }
        public string UserInit { set; get; }
        public string UserUpd { set; get; }
        public string DetailImport { set; get; }

    }
}
