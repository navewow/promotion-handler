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
        public float ApplyPromotion(CartItem cartItem)
        {
            Promotion promotion =  _iDBService.GetPromtionbyType(PromotionType.IndividualPromotion);


            throw new System.NotImplementedException();
        }
    }
}
