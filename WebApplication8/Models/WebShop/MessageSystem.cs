using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.WebShop
{
    public partial class MessageSystem
    {

        public int Id { set; get; }
        [Required]
        public string Content { set; get; }
        [Required]
        public DateTime CreateDate { set; get; }
        [Required]
        [StringLength(20)]
        public string TypeMessage { set; get; }
        [Required]
        public int Status { set; get; }
    }
}
