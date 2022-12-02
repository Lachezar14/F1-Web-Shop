using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic_Layer.Managers;
using Logic_Layer.Interfaces;
using Models;

namespace TheRacingStore.Pages
{
    public class AboutUsModel : PageModel
    {
        //UserManager um = new UserManager();
        private IUserManager _userManager;
        public AboutUsModel(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        public new User User { get; set; }

        //public Product Product { get; set; }    
        public void OnGet()
        {
            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                User = _userManager.GetUser((int)id);
            }

        }
    }
}
