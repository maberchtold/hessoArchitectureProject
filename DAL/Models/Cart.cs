using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public DateTime ShoppingDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<Item> Items { get; } = new List<Item>();
        public ICollection<CartItem> CartItems { get; } = new List<CartItem>();
    }
}
