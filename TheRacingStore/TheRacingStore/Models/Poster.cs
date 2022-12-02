using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Poster : Product
    {
        public int Length { get; private set; }
        public int Height { get; private set; }

        public Poster(int id, string desc, int stock, decimal price, string type, int length, int height) : base(id, desc, stock, price, type)
        {
            Length = length;
            Height = height;
        }

        public Poster(string desc, int stock, decimal price, string type, int length, int height) : base(desc, stock, price, type)
        {
            Length = length;
            Height = height;
        }
        
        public Poster(){}
        
        public override void Discount()
        {
            if (this.Length > 100 && this.Height > 150)
            {
                //10% discount
                this.Price -= (this.Price * 10) / 100;
            }
            else if (this.Length > 200 && this.Height > 250)
            {
                //15% discount
                this.Price -= (this.Price * 15) / 100;
            }
            else if (this.Length > 300 && this.Height > 350)
            {
                //20% discount
                this.Price -= (this.Price * 20) / 100;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Dimensions:{Length}x{Height}cm";
        }
    }
}
