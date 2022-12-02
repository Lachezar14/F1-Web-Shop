using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic_Layer.Interfaces;
using Models;

namespace TheRacingStoreDesktop
{
    public partial class ProductUpdate : Form
    {
        private readonly IProductManager _productManager;
        private Product product;

        public ProductUpdate(Product product, IProductManager _productManager)
        {
            this.product = product;
            this._productManager = _productManager;
            InitializeComponent();
            Info();
        }

        public void Info()
        {
            if (product.Type == "Clothing")
            {
                Clothing clothing = (Clothing)product;
                lbLength.Visible = false;
                tbLength.Visible = false;
                lbHeight.Visible = false;
                tbHeight.Visible = false;
                lbCM1.Visible = false;
                lbCM2.Visible = false;
                lbSize.Visible = true;
                cbSize.Visible = true;
                tbId.Text = clothing.Id.ToString();
                tbDesc.Text = clothing.Description;
                tbPrice.Text = clothing.Price.ToString();
                tbStock.Text = clothing.Stock.ToString();
                cbSize.Text = clothing.Size;
            }
            else if (product.Type == "Poster")
            {
                Poster poster = (Poster)product;
                lbLength.Visible = true;
                tbLength.Visible = true;
                lbHeight.Visible = true;
                tbHeight.Visible = true;
                lbCM1.Visible = true;
                lbCM2.Visible = true;
                lbSize.Visible = false;
                cbSize.Visible = false;
                tbId.Text = poster.Id.ToString();
                tbDesc.Text = poster.Description;
                tbPrice.Text = poster.Price.ToString();
                tbStock.Text = poster.Stock.ToString();
                tbLength.Text = poster.Length.ToString();
                tbHeight.Text = poster.Height.ToString();
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (product.Type == "Clothing")
            {
                Clothing clothing = (Clothing)product;
                clothing = new Clothing(Convert.ToInt32(tbId.Text), tbDesc.Text, Convert.ToInt32(tbStock.Text), Convert.ToDecimal(tbPrice.Text), "Clothing", cbSize.Text);
                _productManager.UpdateProduct(clothing);
                MessageBox.Show("Product updated");
                this.Close();                
            }
            else if (product.Type == "Poster")
            {
                Poster poster = (Poster)product;
                poster = new Poster(Convert.ToInt32(tbId.Text),tbDesc.Text, Convert.ToInt32(tbStock.Text), Convert.ToDecimal(tbPrice.Text), "Poster", Convert.ToInt32(tbLength.Text), Convert.ToInt32(tbHeight.Text));
                _productManager.UpdateProduct(poster);
                MessageBox.Show("Product updated");
                this.Close();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            _productManager.DeleteProduct(Convert.ToInt32(tbId.Text));
            MessageBox.Show("Product deleted");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
