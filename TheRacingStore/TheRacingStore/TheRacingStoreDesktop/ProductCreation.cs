using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic_Layer.Managers;
using Logic_Layer.Interfaces;
using Models;

namespace TheRacingStoreDesktop
{
    public partial class ProductCreation : Form
    {
        private readonly IProductManager _productManager;

        public ProductCreation(IProductManager productManager)
        {
            _productManager = productManager;
            InitializeComponent();
        }
        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == 0)
            {
                Product product = new Clothing(tbDesc.Text, Convert.ToInt32(tbStock.Text), Convert.ToDecimal(tbPrice.Text), "Clothing", cbSize.Text);
                _productManager.AddClothing(product);
                MessageBox.Show("A clothing successfully added");
                this.Close();
            }
            else if(cbType.SelectedIndex == 1)
            {
                Product product = new Poster(tbDesc.Text, Convert.ToInt32(tbStock.Text), Convert.ToDecimal(tbPrice.Text), "Poster", Convert.ToInt32(tbLength.Text), Convert.ToInt32(tbHeight.Text));
                _productManager.AddPoster(product);
                MessageBox.Show("Poster successfully added");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a product type");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductCreation_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == 0)
            {
                lbLength.Visible = false;
                tbLength.Visible = false;
                lbHeight.Visible = false;
                tbHeight.Visible = false;
                lbCM1.Visible = false;
                lbCM2.Visible = false;
                lbSize.Visible = true;
                cbSize.Visible = true;
            }
            else if (cbType.SelectedIndex == 1)
            {
                lbLength.Visible = true;
                tbLength.Visible = true;
                lbHeight.Visible = true;
                tbHeight.Visible = true;
                lbCM1.Visible = true;
                lbCM2.Visible = true;
                lbSize.Visible = false;
                cbSize.Visible = false;
            }
        }
    }
}
