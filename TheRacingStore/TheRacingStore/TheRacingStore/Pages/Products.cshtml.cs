using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logic_Layer.Managers;
using Logic_Layer.Interfaces;
using Models;
using Data_Layer.DBConnections;

namespace TheRacingStore.Pages
{
    public class ProductsModel : PageModel
    {
        //public ProductManager pm = new ProductManager();
        //UserManager _userManager = new UserManager();
        private IUserManager _userManager;
        private ProductManager pm;
        public IProductDB _productDB;
        
        public ProductsModel(IUserManager userManager,IProductDB productDB)
        {
            this._userManager = userManager;
            this._productDB = productDB;
            pm = new ProductManager(productDB); 
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
        //public ActionResult OnPost(){}
    }
}
