using PromotionsLib.Core.PromotionLogics;
using PromotionsLib.DAL;
using PromotionsLib.Models;

namespace PromotionsLib.Core.PromotionLogics
{
    internal class PercentagePromotion : IPromotion
    {
        private IDBService iDBService;

        public PercentagePromotion(IDBService iDBService)
        {
            this.iDBService = iDBService;
        }

        public float ApplyPromotion(CartItem cartItem)
        {
            throw new System.NotImplementedException();
        }
    }
}