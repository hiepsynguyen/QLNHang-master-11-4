using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.CustomerViewModels
{
    public class SearchOrderView
    {
        public string Text { set; get; }
        public string DateStart { set; get; }
        public string DateEnd { set; get; }
        public int Status { set; get; }
    }
}
