using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebHello.Pages
{
    public class Login : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string message { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Login(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if(User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Livres"); 
            }
            return Page(); 

        }

        public async Task<IActionResult> OnPost(string username, string password, string ReturnURL) { 
        
            if(username == "Maryam")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username) 
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnURL == null ? "/Livres/" : ReturnURL); 
            }
            return Page(); 
        }
        
    }
}
