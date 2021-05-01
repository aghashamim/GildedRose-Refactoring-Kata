namespace csharp
{
    public static class GildedRoseItemCatalogue
    {
        private const int LowestPossibleQualityValue = 0;
        private const int HighestPossibleQualityValue = 50;
        private const int HighestPossibleQualityValueForSulfuras = 80;

        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredManaCake = "Conjured Mana Cake";

        public static int GetLowestPossibleQualityValue()
        {
            return LowestPossibleQualityValue;
        }

        public static int GetHighestPossibleQualityValueForItem(Item item)
        {
            switch (item.Name)
            {
                case Sulfuras:
                    return HighestPossibleQualityValueForSulfuras;
                default:
                    return HighestPossibleQualityValue;
            }
        }
    }
}