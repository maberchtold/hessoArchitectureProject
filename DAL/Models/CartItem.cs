using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}
