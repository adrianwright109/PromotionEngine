using PromotionEngine.SharedLibrary;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class Scenarios
    {
        private readonly List<Promotion<ProductBase>> _promotions = new List<Promotion<ProductBase>>()
        {
            new Promotion<ProductBase>(new ProductA(), 3, 130, isActive: true),
            new Promotion<ProductBase>(new ProductB(), 2, 45, isActive: true),
            new Promotion<ProductBase>(new ProductC(), new ProductD(), 30, isActive: true),
            new Promotion<ProductBase>(new ProductD(), new ProductC(), 30, isActive: true)
        };

        [Fact]
        public void ScenarioA()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 1 },
                { new ProductB(), 1 },
                { new ProductC(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, _promotions);

            //ASSERT
            Assert.Equal(100, order.Total);
        }

        [Fact]
        public void ScenarioB()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 5 },
                { new ProductB(), 5 },
                { new ProductC(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, _promotions);

            //ASSERT
            Assert.Equal(370, order.Total);
        }

        [Fact]
        public void ScenarioC()
        {
            var orderItems = new Dictionary<ProductBase, int>
            {
                { new ProductA(), 3 },
                { new ProductB(), 5 },
                { new ProductC(), 1 },
                { new ProductD(), 1 }
            };

            //ARRANGE
            var order = new Order<ProductBase>(orderItems, _promotions);

            //ASSERT
            Assert.Equal(280, order.Total);
        }
    }
}