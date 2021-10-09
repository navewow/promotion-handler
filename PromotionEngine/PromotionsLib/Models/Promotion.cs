using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib.Models
{
    class Promotion
    {
        public string PromotionName { get; set; }
        public int MinQuantity { get; set; }
        public float PromotionPrice { get; set; }
        public List<char> PromotionUnits { get; set; }
        public PromotionType PromotionType { get; set; }
    }

    enum PromotionType
    {
        IndividualPromotion,
        CombinedPromotion,
        PercentagePromotion,
    }
}