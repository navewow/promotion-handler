using PromotionsLib.Core.PromotionLogics;
using PromotionsLib.DAL;
using PromotionsLib.Models;

namespace PromotionsLib.Core.PromotionLogics
{
    internal class CombinedPromotion : IPromotion
    {
        private IDBService iDBService;

        public CombinedPromotion(IDBService iDBService)
        {
            this.iDBService = iDBService;
        }

        public float ApplyPromotion(CartItem cartItem)
        {
            throw new System.NotImplementedException();
        }
    }
}