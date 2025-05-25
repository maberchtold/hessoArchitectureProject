using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public ICollection<Cart> Carts { get; } = new List<Cart>();
        public ICollection<CartItem> CartItems { get; } = new List<CartItem>();
    }
}
