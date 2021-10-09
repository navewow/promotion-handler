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
        public CartItem ProcessPromotion(CartItem cartItem) {

            cartItem.ItemTotalPrice = _iDBService.GetProduct(cartItem.Unit).Price * cartItem.Quantity;
            var eligilePromotions = CheckOfferEligibility(cartItem);
            if (eligilePromotions.Count > 0) {
                CalculatePromotionPrice(cartItem, eligilePromotions);            
            }

            return new CartItem();        
        }

        private void CalculatePromotionPrice(CartItem cartItem, List<Promotion> eligilePromotions)
        {
            foreach (var eligilePromotion in eligilePromotions)
            {
                cartItem.ItemOfferPrice =  GetPromotionProcessor(eligilePromotion.PromotionType).ApplyPromotion(cartItem);                
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

        private List<Promotion> CheckOfferEligibility(CartItem cartItem) {

            List<Promotion> EligiblePromotions = new List<Promotion>(); 

            foreach (var Promotion in _iDBService.GetPromtion(cartItem.Unit))
            {
                if (cartItem.Quantity >= Promotion.MinQuantity)
                    EligiblePromotions.Add(Promotion);

            }

            return EligiblePromotions;
        }
    }
}
