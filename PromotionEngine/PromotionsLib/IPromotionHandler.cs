using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib
{
    public interface IPromotionHandler
    {
        public Cart ApplyPromotion(Cart cart);
    }
}
