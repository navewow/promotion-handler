using PromotionsLib.Core;
using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib
{
    internal class PromotionHandler : IPromotionHandler
    {
        private readonly PromotionProcessor _promotionProcessor;
        public PromotionHandler(PromotionProcessor promotionProcessor)
        {
            _promotionProcessor = promotionProcessor;
        }
        public Cart ApplyPromotion(Cart cart)
        {
            Cart PromotedCart = new Cart();
            PromotedCart.CartItems = new List<CartItem>();
            foreach (CartItem cartItem in cart.CartItems)
            {
                PromotedCart.CartItems.Add(_promotionProcessor.ProcessPromotion(cartItem, cart));
            }

            foreach (var item in PromotedCart.CartItems)
            {
                if (string.IsNullOrEmpty(item.PromoApplied))
                {
                    PromotedCart.CartTotal += item.ItemTotalPrice;
                }
                else {
                    PromotedCart.CartTotal += item.ItemOfferPrice;
                }
            }

            return PromotedCart;
        }
    }
}
