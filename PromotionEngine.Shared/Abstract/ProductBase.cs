namespace PromotionEngine.SharedLibrary
{
    public abstract class ProductBase
    {
        public abstract string SkuId { get; }

        public abstract int UnitPrice { get; }
    }
}