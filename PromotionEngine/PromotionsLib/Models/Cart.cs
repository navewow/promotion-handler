using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }
        public float CartTotal { get; set; }
    }

    public class CartItem
    {
        public char Unit { get; set; }
        public int Quantity { get; set; }
        public float ItemTotalPrice { get; set; }
        public float ItemOfferPrice { get; set; }
        public string PromoApplied { get; set; }
        public float UnitPrice { get;  set; }
    }
}
