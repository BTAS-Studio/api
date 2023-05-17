using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.BlazorApp.Controllers
{
    [Route("/[Controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet("microsoft")]
        public async Task<ActionResult> Login(string redirectUri)
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = redirectUri
            };

            return Challenge(props, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
