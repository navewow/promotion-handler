using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Models;
using PromotionsLib;
using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionHandler _promotionHandler;
        public PromotionsController(IPromotionHandler promotionHandler)
        {
            _promotionHandler = promotionHandler;
        }

        [HttpPost]
        public IActionResult ProcessPromotion([FromBody]CartRequest cartReq) {

            Cart cart= ProcessRequest(cartReq);
            var promotedCart =_promotionHandler.ApplyPromotion(cart);
            return Ok(promotedCart);
        }

        private Cart ProcessRequest(CartRequest cartReq)
        {
            if (isValidRequest(cartReq))
            {
                Cart cart = new Cart();
                cart.CartItems = new List<PromotionsLib.Models.CartItem>();
                foreach (var item in cartReq.CartItems)
                {
                    cart.CartItems.Add(new PromotionsLib.Models.CartItem
                    {
                        Unit = item.Unit,
                        Quantity = item.Quantity
                    });
                }

                return cart;
            }
            else {
                throw new ArgumentException("ValidationError");
            }
        }

        private bool isValidRequest(CartRequest cartReq)
        {
            return true;
        }
    }
}
