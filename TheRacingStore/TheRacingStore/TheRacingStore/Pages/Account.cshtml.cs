using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Logic_Layer.Managers;
using Logic_Layer.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TheRacingStore.Pages
{
    [Authorize]
    public class AccountModel : PageModel
    {
        //UserManager um = new UserManager();
        private IUserManager _userManager;
        public AccountModel(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        //[BindProperty]
        public User User { get; set; }

        [BindProperty]
        public UserDTO UserDTO { get; set; }

        public void OnGet()
        {
            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                User = _userManager.GetUser((int)id);
            }
        }
       
        public void OnPostChangeUser() 
        {
            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                User = _userManager.GetUser((int)id);
            }
            
            UserDTO.Id = (int)HttpContext.Session.GetInt32("User_Id")!;
            UserDTO.Type = User.Type;
            
            if (ModelState.IsValid)
            {
                User = new User(UserDTO);
                _userManager.UpdateUser(User);
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return new RedirectToPageResult("Index");
        }
    }
}
