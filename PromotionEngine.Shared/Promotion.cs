namespace PromotionEngine.Shared
{
    public class Promotion<TProduct> where TProduct : ProductBase
    {
        public Promotion(TProduct promotionalProduct, int? quantityTheshold, int discountedPrice, bool isActive)
        {
            PromotionalProduct = promotionalProduct;
            QuantityTheshold = quantityTheshold;
            DiscountedPrice = discountedPrice;
            IsActive = isActive;
        }

        public Promotion(TProduct promotionalProduct, TProduct linkedProduct, int discountedPrice, bool isActive)
        {
            PromotionalProduct = promotionalProduct;
            LinkedProduct = linkedProduct;
            DiscountedPrice = discountedPrice;
            IsActive = isActive;
        }

        public TProduct PromotionalProduct { get; }

        public TProduct? LinkedProduct { get; }

        public int? QuantityTheshold { get; }

        public int DiscountedPrice { get; }

        public bool IsActive { get; }
    }
}
