using PromotionsLib.DAL;
using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib.Core.PromotionLogics
{
    class IndividualPromotion : IPromotion
    {
        private readonly IDBService _iDBService;

        public IndividualPromotion(IDBService iDBService)
        {
            _iDBService = iDBService;
        }
        public void ApplyPromotion(Cart cart, Promotion promotion)
        {
            var cartItem = cart.CartItems.First(p => p.Unit == promotion.PromotionUnits.First());

            int offerapplicableQuantity =  (int) (cartItem.Quantity / promotion.MinQuantity);
            int offerNotApplicable = cartItem.Quantity % promotion.MinQuantity;

            cartItem.PromoApplied = promotion.PromotionName;
            cartItem.ItemOfferPrice = (offerapplicableQuantity * promotion.PromotionPrice) + (offerNotApplicable * cartItem.UnitPrice);
        }
    }
}
