using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Logic_Layer.Interfaces;
using Logic_Layer.Managers;

namespace TheRacingStoreDesktop
{
    public partial class UserManagement : Form
    {
        private User user = new User();
        private IUserManager _userManager;
        
        public UserManagement(IUserManager userManager)
        {
            this._userManager = userManager;
            InitializeComponent();
        }
        
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == 0)
            {
                User user = new User(tbFName.Text, tbLName.Text, tbEmail.Text, tbPhone.Text, tbAddress.Text, tbCity.Text, tbPostcode.Text, "Admin", tbUsername.Text, tbPassword.Text);
                _userManager.AddNewAdmin(user);
                MessageBox.Show("New Admin added.");
                this.Close();
            }
            else if (cbType.SelectedIndex == 1)
            {
                User user = new User(tbFName.Text, tbLName.Text, tbEmail.Text, tbPhone.Text, tbAddress.Text, tbCity.Text, tbPostcode.Text, "Customer", tbUsername.Text, tbPassword.Text);
                _userManager.AddNewCustomer(user);
                MessageBox.Show("New Customer added.");
                this.Close();
            }
            else { MessageBox.Show("Please select account type."); }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
