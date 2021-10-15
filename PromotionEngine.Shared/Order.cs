
namespace PromotionEngine.Shared
{
    public class Order<TProduct> where TProduct : ProductBase
    {
        public Order(List<TProduct> orderItems)
        {
            Items = orderItems;
            ActivePromotions = new List<Promotion<TProduct>>();    
        }

        public Order(List<TProduct> orderItems, List<Promotion<TProduct>> promotions)
        {
            Items = orderItems;
            ActivePromotions = promotions.Where(x => x.IsActive).ToList();
        }

        public List<TProduct> Items { get; }

        public List<Promotion<TProduct>> ActivePromotions { get; }

        public int Total => Items.Sum(x => x.UnitPrice);
    }
}
