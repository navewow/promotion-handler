using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsLib.DAL
{
    internal class DBService : IDBService
    {

        public List<Promotion> GetPromtion(Char Unit) {
            return GetAllPromotions().Where(p => p.PromotionUnits.Contains(Unit)).ToList();
        }

        public Promotion GetPromtionbyType(PromotionType promotionType)
        {
            return GetAllPromotions().FirstOrDefault(p => p.PromotionType == promotionType);
        }

        public List<Promotion> GetAllPromotions() {

            return new List<Promotion>
            {
                new Promotion { 
                    MinQuantity = 3,
                    PromotionPrice = 130,
                    PromotionUnits = new List<char> {'A'},
                    PromotionName = "Get 3 A for 130",
                    PromotionType = PromotionType.IndividualPromotion
                },
                new Promotion {
                    MinQuantity = 2,
                    PromotionPrice = 45,
                    PromotionUnits = new List<char> {'B'},
                    PromotionName = "Get 2 B for 45",
                    PromotionType = PromotionType.IndividualPromotion
                },
                new Promotion {
                    MinQuantity = 1,
                    PromotionPrice = 30,
                    PromotionUnits = new List<char> {'C', 'D'},
                    PromotionName = "Get C & D Product",
                    PromotionType = PromotionType.CombinedPromotion
                }
            };
        }

        public Product GetProduct(char Unit) {
            return GetAllProduct().FirstOrDefault(p => p.Unit.Equals(Unit));
        }

        public List<Product> GetAllProduct() {
            return new List<Product> {
                new Product {
                    Unit = 'A',
                    Price = 50
                },
                new Product {
                    Unit = 'B',
                    Price = 30
                },
                new Product {
                    Unit = 'C',
                    Price = 20
                },
                new Product {
                    Unit = 'D',
                    Price = 15
                }
            };
        
        }
    }
}
