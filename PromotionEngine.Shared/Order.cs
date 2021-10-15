
namespace PromotionEngine.Shared
{
    public class Order<TProduct> where TProduct : ProductBase
    {
        public Order(List<TProduct> orderItems)
        {
            Items = orderItems;
        }

        public List<TProduct> Items { get; }

        public int Total => Items.Sum(x => x.UnitPrice);
    }
}
