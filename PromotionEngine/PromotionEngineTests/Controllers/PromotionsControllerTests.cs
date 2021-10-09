using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionEngine.Controllers;
using PromotionsLib;
using PromotionsLib.DAL;
using PromotionsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace PromotionEngine.Controllers.Tests
{
    [TestClass()]
    public class PromotionsControllerTests
    {
        [TestMethod()]
        public void ProcessPromotionTest()
        {
            var mockRepo = new Mock<IPromotionHandler>();
            mockRepo.Setup(repo => repo.ApplyPromotion(It.IsAny<Cart>()))
                .Returns(new Cart { 
                    CartItems = new List<CartItem> { 
                        new CartItem { UnitPrice = 50, ItemOfferPrice = 130, Quantity = 3, ItemTotalPrice = 150, PromoApplied = "Get 3 A for 130", Unit = 'A' },
                        new CartItem { UnitPrice = 30, ItemOfferPrice = 45, Quantity = 2, ItemTotalPrice = 60, PromoApplied = "Get 2 B for 45", Unit = 'B' },
                        new CartItem { UnitPrice = 20, ItemOfferPrice = 20, Quantity = 1, ItemTotalPrice = 20, PromoApplied = "", Unit = 'C' }
                    },
                    CartTotal = 370
                });

            var controller = new PromotionsController(mockRepo.Object);

            var result = controller.ProcessPromotion(new Models.CartRequest
            {
                CartItems = new List<Models.CartItem>
                {
                    new Models.CartItem {Unit = 'A', Quantity = 5 },
                    new Models.CartItem {Unit = 'B', Quantity = 5 },
                    new Models.CartItem {Unit = 'C', Quantity = 1 }
                }
            });

            var contentResult = result as ObjectResult;
            var PromoCart = contentResult.Value as Cart;

            Assert.IsNotNull(PromoCart);
            Assert.IsNotNull(PromoCart.CartItems);
            Assert.AreEqual(370, PromoCart.CartTotal);

        }

        [TestMethod()]
        public void NoMockProcessPromotionTest()
        {
         
            var controller = new PromotionsController(new PromotionHandler( new PromotionsLib.Core.PromotionProcessor(new DBService())));

            var result = controller.ProcessPromotion(new Models.CartRequest
            {
                CartItems = new List<Models.CartItem>
                {
                    new Models.CartItem {Unit = 'A', Quantity = 5 },
                    new Models.CartItem {Unit = 'B', Quantity = 5 },
                    new Models.CartItem {Unit = 'C', Quantity = 1 }
                }
            });

            var contentResult = result as ObjectResult;
            var PromoCart = contentResult.Value as Cart;

            Assert.IsNotNull(PromoCart);
            Assert.IsNotNull(PromoCart.CartItems);
            Assert.AreEqual(370, PromoCart.CartTotal);

        }
    }
}