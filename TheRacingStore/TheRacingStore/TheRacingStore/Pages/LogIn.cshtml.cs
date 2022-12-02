using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Logic_Layer.Interfaces;
using Logic_Layer.Managers;
using System.Security.Claims;
using Data_Layer.DBConnections;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace TheRacingStore.Pages
{
    public class LogInModel : PageModel
    {
       //private IUserDB userDb;

       //private UserManager _userManager;
        private IUserManager _userManager;
        public LogInModel(IUserManager userManager)
        {
            //_userManager = new UserManager(userDb);
            this._userManager = userManager;
        }

        //[BindProperty]
        //public User User { get; set; }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
            
        }

        public async void Auth(string user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        }
        
        public IActionResult OnPost() 
        {
            User user = _userManager.GetUserByLogin(Username, Password);
            
                if (user != null)
                {
                    HttpContext.Session.SetInt32("User_Id",user.Id);
                    Auth(user.ToString());
                    return RedirectToPage("Account");
                }
                else 
                {
                    return Page();
                }
        }
    }
}
