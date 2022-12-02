using Logic_Layer.Managers;
using Logic_Layer.Interfaces;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheRacingStore.Pages
{
    public class OrderModel : PageModel
    {
        private IUserManager _userManager;
        private IProductManager _productManager;
        private IOrderManager _orderManager;

        public OrderModel(IUserManager userManager, IProductManager productManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _productManager = productManager;
            _orderManager = orderManager;
        }

        [BindProperty] 
        public UserDTO User { get; set; }

        public User UserLoged { get; set; }
        
        [BindProperty(SupportsGet = true)] 
        public int Id { get; set; }

        [BindProperty] 
        public Product Product { get; set; }

        [BindProperty] 
        public Order Order { get; set; }

        public void OnGet()
        {
            Product = _productManager.GetProduct(Id);
            Product.Discount();

            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                UserLoged = _userManager.GetUser((int) id);
            }
        }


        public IActionResult OnPostOrder()
        {
           var id = Request.Form["ProductId"];
           Id = Convert.ToInt32(id);
           Product = _productManager.GetProduct(Id);
           Product.Discount();
           
           if (ModelState.IsValid)
           {
                if (HttpContext.Session.GetInt32("User_Id") is null)
                {
                    UserLoged = new User(User);
                    _userManager.AddNewCustomer(UserLoged);
                }
                else
                {
                    User.Id = (int)HttpContext.Session.GetInt32("User_Id");
                    UserLoged = _userManager.GetUser(User.Id);
                }

                Order = new Order(Product, UserLoged, 0);
             
                _orderManager.AddOrder(Order);
                _productManager.ProductBought(Id);
                return new RedirectToPageResult("OrderConfirmed");
           }
           return Page();
       }
    }
}
