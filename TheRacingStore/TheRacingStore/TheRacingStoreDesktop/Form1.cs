using Logic_Layer.Interfaces;
using Logic_Layer.Managers;
using Models;

namespace TheRacingStoreDesktop
{
    public partial class Form1 : Form
    {
        private readonly IUserManager _userManager;
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;
        public Form1(IUserManager userManager, IProductManager productManager, IOrderManager orderManager)
        {
            _userManager = userManager;
            _productManager = productManager;
            _orderManager = orderManager;
            InitializeComponent();
            UpdateGUI();
            
        }
     
        public void UpdateGUI()
        {
            lbUsers.DataSource = _userManager.GetAllUsers();
            lbProducts.DataSource = _productManager.GetAllProducts();
            lbOrders.DataSource = _orderManager.GetAllOrders();
        }
       
        private void btnProducts_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpProducts;
            UpdateGUI();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpUsers;
            UpdateGUI();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpHome;
            UpdateGUI();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpOrders;
            UpdateGUI();
        }

        private void tpHome_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedValue != null)
            {
                User user = (User)lbUsers.SelectedValue;
                UserUpdate userUpdate = new UserUpdate(user, _userManager);
                userUpdate.Show();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserManagement userManagement = new UserManagement(_userManager);
            userManagement.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductCreation productCreation = new ProductCreation(_productManager);
            productCreation.Show();
        }

        private void lbUsers_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        Order order = new Order();
        private void lbOrders_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbOrders.SelectedValue != null) 
            {
                order = (Order)lbOrders.SelectedValue;
                if (order.Shipped == 1)
                {
                    tbStatus.Text = "shipped";
                }
                else
                {
                    tbStatus.Text = "to be shipped";
                }
            }
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            if (order.Shipped == 1)
            {
                MessageBox.Show("Order was already shipped");
            }
            else
            {
                _orderManager.OrderShipped(order.Id);
                MessageBox.Show("Order has been shipped");
            }

            UpdateGUI();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (lbProducts.SelectedValue != null)
            {
                
                Product product = (Product)lbProducts.SelectedValue;
                if (product.Type == "Clothing")
                {
                    Clothing clothing = (Clothing)product;
                    ProductUpdate productUpdate = new ProductUpdate(clothing, _productManager);
                    productUpdate.Show();
                }
                else if (product.Type == "Poster")
                {
                    Poster poster = (Poster)product;
                    ProductUpdate productUpdate = new ProductUpdate(poster, _productManager);
                    productUpdate.Show();
                }
            }
        }
    }
}