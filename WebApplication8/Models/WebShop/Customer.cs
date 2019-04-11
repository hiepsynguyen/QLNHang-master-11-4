using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.WebShop
{
    public partial class Customer
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Fullname")]
        public string Fullname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool Activated { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
