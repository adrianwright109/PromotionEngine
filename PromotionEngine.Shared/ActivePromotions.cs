namespace PromotionEngine.SharedLibrary
{
    public static class ActivePromotions
    {
        public static List<Promotion<ProductBase>> Promotions = new List<Promotion<ProductBase>>()
        {
            new Promotion<ProductBase>(new ProductA(), 3, 130, isActive: true),
            new Promotion<ProductBase>(new ProductB(), 2, 45, isActive: true),
            new Promotion<ProductBase>(new ProductC(), new ProductD(), 30, isActive: true),
            new Promotion<ProductBase>(new ProductD(), new ProductC(), 30, isActive: true)
        };
    }
}
