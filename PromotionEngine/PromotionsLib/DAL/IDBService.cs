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
        List<Promotion> GetAllPromotions();
    }
}
