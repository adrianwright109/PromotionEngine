using PromotionEngine.SharedLibrary;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class WithActivePromotion
    {
        [Fact]
        public void TwoUnitsOfProductAWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 2 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(100, order.Total);
        }

        [Fact]
        public void ThreeUnitsOfProductAWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 3 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(130, order.Total);
        }

        [Fact]
        public void FourUnitsOfProductAWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 4 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(180, order.Total);
        }

        [Fact]
        public void OneUnitOfProductBWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductB(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(30, order.Total);
        }

        [Fact]
        public void TwoUnitsOfProductBWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductB(), 2 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(45, order.Total);
        }

        [Fact]
        public void ThreeUnitsOfProductBWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductB(), 3 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(75, order.Total);
        }

        [Fact]
        public void OneUnitOfProductCWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductC(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(20, order.Total);
        }

        [Fact]
        public void TwoUnitsOfProductCWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductC(), 2 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(40, order.Total);
        }

        [Fact]
        public void OneUnitOfProductCAndOneUnitOfProductDWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductC(), 1 },
                { new ProductD(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(30, order.Total);
        }

        [Fact]
        public void OneUnitOfProductDWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductD(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(15, order.Total);
        }

        [Fact]
        public void TwoUnitsOfProductDWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductD(), 2 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(30, order.Total);
        }

        [Fact]
        public void OneUnitOfProductDAndOneUnitOfProductCWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductD(), 1 },
                { new ProductC(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, ActivePromotions.Promotions);

            //ACT
            order.CalculateTotal();

            //ASSERT
            Assert.Equal(30, order.Total);
        }
    }
}