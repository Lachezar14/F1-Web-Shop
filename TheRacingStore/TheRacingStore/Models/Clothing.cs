using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Clothing : Product
    {
        public string  Size { get; private set; }

        public Clothing(int id, string desc, int stock, decimal price, string type, string size) : base(id, desc, stock, price, type)
        {
            this.Size = size;
        }

        public Clothing(string desc, int stock, decimal price, string type, string size) : base(desc, stock, price, type)
        {
            this.Size = size;
        }

        public Clothing(){}
        
        public override void Discount()
        {
            if (this.Price > 20)
            {
                //10% discount
                this.Price -= (this.Price * 10) / 100;
            }
            else if (this.Price > 40)
            {
                //15% discount
                this.Price -= (this.Price * 15) / 100;
            }
            else if (this.Price > 60)
            {
                //20% discount
                this.Price -= (this.Price * 20) / 100;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Size: {Size}";
        }
    }
}
