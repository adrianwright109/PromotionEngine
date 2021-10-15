using PromotionEngine.Shared;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class WithNoPromotions
    {
        [Fact]
        public void OneUnitOfProductAWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(50, order.Total);
        }

        [Fact]
        public void OneUnitOfProductBWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductB(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(30, order.Total);
        }

        [Fact]
        public void OneUnitOfProductCWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductC(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(20, order.Total);
        }

        [Fact]
        public void OneUnitOfProductDWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductD(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(15, order.Total);
        }

        [Fact]
        public void OneUnitOfEachProductWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 1 },
                { new ProductB(), 1 },
                { new ProductC(), 1 },
                { new ProductD(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(50 + 30 + 20 + 15, order.Total);
        }
    }
}