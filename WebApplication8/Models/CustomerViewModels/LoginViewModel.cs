using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.CustomerViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

    }
}
