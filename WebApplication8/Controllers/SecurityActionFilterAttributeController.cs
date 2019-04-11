using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using WebApplication8.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace WebApplication8.Controllers
{
   
    public class SecurityActionFilterAttributeController 
    {
        
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public SecurityActionFilterAttributeController(IApplicationBuilder app) {
           
            _userManager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
            _roleManager= app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
        }
       
        
    }
}