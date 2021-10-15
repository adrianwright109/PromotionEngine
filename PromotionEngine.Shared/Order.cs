
namespace PromotionEngine.SharedLibrary
{
    public class Order<TProduct> where TProduct : ProductBase
    {
        public Order(Dictionary<TProduct, int> orderItems)
        {
            AllOrderItems = orderItems;
            ActivePromotions = new List<Promotion<TProduct>>();    
        }

        public Order(Dictionary<TProduct, int> orderItems, List<Promotion<TProduct>> promotions)
        {
            AllOrderItems = orderItems;
            ActivePromotions = promotions.Where(x => x.IsActive).ToList();
        }

        public Dictionary<TProduct, int> AllOrderItems { get; }

        public Dictionary<TProduct, int> OrderItemsWithQuantities => AllOrderItems.Where(x => x.Value > 0).ToDictionary(x => x.Key, x=> x.Value);

        public List<Promotion<TProduct>> ActivePromotions { get; }

        public void UpdateQuantity(TProduct orderItem, int newQuantity)
        {
            if (AllOrderItems.ContainsKey(orderItem))
            {
                AllOrderItems[orderItem] = newQuantity;
                CalculateTotal();
            }
        }

        public int Total { get; private set; }

        public void CalculateTotal()
        {
            Total = 0;
            var linkedProductSkuIdsAlreadyCalculated = new List<string>();

            foreach (var item in OrderItemsWithQuantities)
            {
                var hasPromotion = false;

                foreach (var promotion in ActivePromotions)
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

                                Total += promotion.DiscountedPrice * ((quantityOfThisProductOnOrder - numberOverTheshold) / promotion.QuantityTheshold.Value);

                                if (numberOverTheshold > 0)
                                {
                                    Total += numberOverTheshold * item.Key.UnitPrice;
                                }
                            }
                            else
                            {
                                Total += quantityOfThisProductOnOrder * item.Key.UnitPrice;
                            }
                        }
                        else if (promotion.LinkedProduct is not null)
                        {
                            var orderContainsALinkedProductForPromotionalDiscount = false;

                            foreach (var linkedProduct in OrderItemsWithQuantities)
                            {
                                if (!LinkedProductsAlreadyCalculated(item.Key.SkuId, promotion.LinkedProduct.SkuId)
                                        && linkedProduct.Key.SkuId == promotion.LinkedProduct.SkuId)
                                {
                                    SetLinkedProductsAlreadyCalculated(item.Key.SkuId, promotion.LinkedProduct.SkuId);

                                    orderContainsALinkedProductForPromotionalDiscount = true;
                                    Total += promotion.DiscountedPrice;
                                }
                            }

                            if (!LinkedProductsAlreadyCalculated(item.Key.SkuId, promotion.LinkedProduct.SkuId)
                                    && !orderContainsALinkedProductForPromotionalDiscount)
                            {
                                Total += item.Value * item.Key.UnitPrice;
                            }
                        }
                    }
                }

                if (!hasPromotion)
                {
                    Total += item.Value * item.Key.UnitPrice;
                }
            }

            void SetLinkedProductsAlreadyCalculated(string productSkuId, string linkedProductSkuId)
            {
                linkedProductSkuIdsAlreadyCalculated.Add(productSkuId);
                linkedProductSkuIdsAlreadyCalculated.Add(linkedProductSkuId);
            }

            bool LinkedProductsAlreadyCalculated(string productSkuId, string linkedProductSkuId)
            {
                return linkedProductSkuIdsAlreadyCalculated.Contains(productSkuId)
                                    && linkedProductSkuIdsAlreadyCalculated.Contains(linkedProductSkuId);
            }
        }
    }
}
