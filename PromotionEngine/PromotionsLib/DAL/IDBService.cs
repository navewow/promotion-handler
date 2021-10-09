using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib.DAL
{
    interface IDBService
    {
        List<Promotion> GetPromtion(Char Unit);
        Promotion GetPromtionbyType(PromotionType promotionType);
        List<Promotion> GetAllPromotions();
        Product GetProduct(char Unit);
        List<Product> GetAllProduct();
    }
}
