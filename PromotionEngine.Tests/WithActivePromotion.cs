using PromotionEngine.Shared;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class WithActivePromotion
    {
        private readonly List<Promotion<ProductBase>> _promotions = new List<Promotion<ProductBase>>()
        {
            new Promotion<ProductBase>(new ProductA(), 3, 130, isActive: true),
            new Promotion<ProductBase>(new ProductB(), 2, 45, isActive: true),
            new Promotion<ProductBase>(new ProductC(), new ProductD(), 30, isActive: true),
            new Promotion<ProductBase>(new ProductD(), new ProductC(), 30, isActive: true)
        };

        [Fact]
        public void ThreeUnitsOfProductAWithPromotionAppliedHasCorrectTotal()
        {
            var orderItems = new List<ProductBase>
            {
                new ProductA(),
                new ProductA(),
                new ProductA()
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, _promotions);

            //ASSERT
            Assert.Equal(130, order.Total);
        }
    }
}