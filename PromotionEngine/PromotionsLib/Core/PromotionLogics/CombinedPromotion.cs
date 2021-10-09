using PromotionsLib.Core.PromotionLogics;
using PromotionsLib.DAL;
using PromotionsLib.Models;
using System.Linq;

namespace PromotionsLib.Core.PromotionLogics
{
    internal class CombinedPromotion : IPromotion
    {
        private IDBService iDBService;

        public CombinedPromotion(IDBService iDBService)
        {
            this.iDBService = iDBService;
        }

        public void ApplyPromotion(Cart cart, Promotion eligilePromotion)
        {
            var commonItems = cart.CartItems.Select(s1 => s1.Unit).ToList().Intersect(eligilePromotion.PromotionUnits).ToList();
            
            foreach (var item in commonItems)
            {
                cart.CartItems.First(x => x.Unit == item).PromoApplied = eligilePromotion.PromotionName;                
            }
            cart.CartItems.First(x => x.Unit == commonItems.Last()).ItemOfferPrice = eligilePromotion.PromotionPrice;
        }
    }
}