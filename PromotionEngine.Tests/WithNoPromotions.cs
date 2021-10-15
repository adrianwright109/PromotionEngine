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
            var orderItems = new List<ProductBase>
            {
                new ProductA()
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(50, order.Total);
        }

        [Fact]
        public void OneUnitOfProductBWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new List<ProductBase>
            {
                new ProductB()
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(30, order.Total);
        }

        [Fact]
        public void OneUnitOfProductCWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new List<ProductBase>
            {
                new ProductC()
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(20, order.Total);
        }

        [Fact]
        public void OneUnitOfProductDWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new List<ProductBase>
            {
                new ProductD()
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(15, order.Total);
        }

        [Fact]
        public void OneUnitOfEachProductWithNoPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new List<ProductBase>
            {
                new ProductA(),
                new ProductB(),
                new ProductC(),
                new ProductD()
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems);

            //ASSERT
            Assert.Equal(50 + 30 + 20 + 15, order.Total);
        }
    }
}