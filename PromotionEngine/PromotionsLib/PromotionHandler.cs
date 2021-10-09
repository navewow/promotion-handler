using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib
{
    class PromotionHandler : IPromotionHandler
    { 
        public Cart ApplyPromotion(Cart cart)
        {
            Cart PromotedCart = new Cart();
            foreach (CartItem cartItem in cart.CartItems)
            {

            }

            return PromotedCart;
        }
    }
}
