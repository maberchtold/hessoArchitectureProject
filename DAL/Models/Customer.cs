using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer : Person
    {
        public int CustomerId { get; set; }
        public string ShoppingAddress { get; set; }

        public ICollection<Cart> Carts { get; } = new List<Cart>();
    }
}
