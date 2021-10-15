
namespace PromotionEngine.Shared
{
    public class Order<TProduct> where TProduct : ProductBase
    {
        public Order(Dictionary<TProduct, int> orderItems)
        {
            Items = orderItems;
            ActivePromotions = new List<Promotion<TProduct>>();    
        }

        public Order(Dictionary<TProduct, int> orderItems, List<Promotion<TProduct>> promotions)
        {
            Items = orderItems;
            ActivePromotions = promotions.Where(x => x.IsActive).ToList();
        }

        public Dictionary<TProduct, int> Items { get; }

        public List<Promotion<TProduct>> ActivePromotions { get; }

        public int Total
        {
            get
            {
                var total = 0;

                foreach(var item in Items)
                {
                    var hasPromotion = false;

                    foreach(var promotion in ActivePromotions)
                    {
                        if (item.Key.SkuId == promotion.PromotionalProduct.SkuId)
                        {
                            hasPromotion = true;

                            if (promotion.QuantityTheshold.HasValue)
                            {
                                var quantityOfThisProductOnOrder = item.Value;

                                if (quantityOfThisProductOnOrder >= promotion.QuantityTheshold.Value)
                                {
                                    var numberOverTheshold = quantityOfThisProductOnOrder % promotion.QuantityTheshold.Value;

                                    total += promotion.DiscountedPrice;

                                    if (numberOverTheshold > 0)
                                    {
                                        total += numberOverTheshold * item.Key.UnitPrice;
                                    }
                                }
                                else
                                {
                                    total += quantityOfThisProductOnOrder * item.Key.UnitPrice;
                                }
                            }
                            else if (promotion.LinkedProduct is not null)
                            {

                            }
                        }
                    }

                    if (!hasPromotion)
                    {
                        total += item.Value * item.Key.UnitPrice;
                    }
                }

                return total;
            }
        }
    }
}
