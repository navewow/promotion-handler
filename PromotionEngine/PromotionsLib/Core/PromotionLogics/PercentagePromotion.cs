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

        public void ApplyPromotion(Cart cart, Promotion eligilePromotion)
        {
            throw new System.NotImplementedException();
        }
    }
}