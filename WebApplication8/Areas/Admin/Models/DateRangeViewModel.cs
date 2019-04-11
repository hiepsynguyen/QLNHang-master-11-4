using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Areas.Admin.Models
{
    public class DateRangeViewModel
    {
        [DataType(DataType.Date)]
        public DateTime StrDate { set; get; }
        [DataType(DataType.Date)]
        public DateTime EndDate { set; get; }

    }
}
