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
    public partial class UserUpdate : Form
    {
        private readonly IUserManager _userManager;
        private User user;
        public UserUpdate(User user, IUserManager userManager)
        {
            _userManager = userManager;
            this.user = user;
            InitializeComponent();
            Info();
        }

        public void Info()
        {
            tbId.Text = user.Id.ToString();
            tbId.ReadOnly = true;
            tbFirstName.Text = user.FName;
            tbLastName.Text = user.LName;
            tbEmail.Text = user.Email;
            tbPhone.Text = user.Phone;
            tbAddress.Text = user.Address;
            tbCity.Text = user.City;
            tbPostcode.Text = user.Postcode;
            cbType.Text = user.Type;
            tbUsername.Text = user.Username;
            tbPassword.Text = user.Password;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            User user = new User(Convert.ToInt32(tbId.Text), tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPhone.Text, tbAddress.Text, tbCity.Text, tbPostcode.Text, cbType.SelectedItem.ToString(), tbUsername.Text, tbPassword.Text);
            _userManager.UpdateUser(user);
            MessageBox.Show("User has been updated");
            this.Close();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            _userManager.DeleteUser(Convert.ToInt32(tbId.Text));
            MessageBox.Show("User has been deleted");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
