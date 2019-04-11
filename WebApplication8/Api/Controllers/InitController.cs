using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebApplication8.Models;

namespace WebApplication8.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Init")]
    public class InitController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public InitController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult GetInits() {
            return Ok("OK");
        }

        [HttpGet("{username,password}", Name = "Login")]
        public async Task<IActionResult> Login(string username, string password)
        {

            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

            if (result.Succeeded) {
                return Ok(new {allow=1,email=username });
            }
            return Ok(new { allow = 0, email = username });
        }



    }
}