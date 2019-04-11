using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.CustomerViewModels
{
    public class CustomerSs
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool Activated { get; set; }
        public string Address { get; set; }
    }
}
