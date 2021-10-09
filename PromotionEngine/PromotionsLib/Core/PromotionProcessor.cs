using PromotionsLib.Core.PromotionLogics;
using PromotionsLib.DAL;
using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib.Core
{
    class PromotionProcessor 
    {
        private readonly IDBService _iDBService;

        public PromotionProcessor(IDBService iDBService)
        {
            _iDBService = iDBService;
        }
        public CartItem ProcessPromotion(CartItem cartItem, Cart cart) {

            var UnitPrice = _iDBService.GetProduct(cartItem.Unit).Price;
            cartItem.ItemTotalPrice = UnitPrice * cartItem.Quantity;
            //cartItem.ItemOfferPrice = cartItem.ItemTotalPrice;
            cartItem.UnitPrice = UnitPrice;

            var eligilePromotions = CheckOfferEligibility(cartItem, cart.CartItems);
            if (eligilePromotions.Count > 0) {
                CalculatePromotionPrice(cart, eligilePromotions);            
            }

            return cartItem;        
        }

        private List<Promotion> CheckOfferEligibility(CartItem cartItem, List<CartItem> cartItems)
        {
            List<Promotion> EligiblePromotions = new List<Promotion>();

            if (string.IsNullOrEmpty(cartItem.PromoApplied)) {
                foreach (Promotion promotion in _iDBService.GetPromtion(cartItem.Unit))
                {
                    switch (promotion.PromotionType)
                    {
                        case PromotionType.IndividualPromotion:
                            if (cartItem.Quantity >= promotion.MinQuantity)
                                EligiblePromotions.Add(promotion);
                            break;
                        case PromotionType.CombinedPromotion:
                            if (!promotion.PromotionUnits.Except(cartItems.Select(x => x.Unit)).Any()) { 
                                EligiblePromotions.Add(promotion);
                            }
                            break;
                        case PromotionType.PercentagePromotion:
                            break;
                        default:
                            break;
                    }
                }
            }
            
            return EligiblePromotions;
        }

        private void CalculatePromotionPrice(Cart cart, List<Promotion> eligilePromotions)
        {
            foreach (var eligilePromotion in eligilePromotions)
            {
                GetPromotionProcessor(eligilePromotion.PromotionType).ApplyPromotion(cart, eligilePromotion);                
            }
        }

        private IPromotion GetPromotionProcessor(PromotionType promotionType) {
            switch (promotionType)
            {
                case PromotionType.IndividualPromotion:
                    return new IndividualPromotion(_iDBService);                    
                case PromotionType.CombinedPromotion:
                    return new CombinedPromotion(_iDBService);                    
                case PromotionType.PercentagePromotion:
                    return new PercentagePromotion(_iDBService);
            }
            throw new ArgumentException("Invalid Promotion");
        }

        
    }
}
