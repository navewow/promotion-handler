using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class CartRequest
    {
        public List<CartItem> CartItems { get; set; }
       
    }

    public class CartItem
    {
        public char Unit { get; set; }
        public int Quantity { get; set; }
    }
}