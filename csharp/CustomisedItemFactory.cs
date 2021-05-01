using csharp.Items;

namespace csharp
{
    public static class CustomisedItemFactory
    {
        public static IGuildedRoseItemQualityUpdateStrategy Create(Item item)
        {
            switch (item.Name)
            {
                case GildedRoseItemCatalogue.AgedBrie:
                    return new AgedBrie(item);
                case GildedRoseItemCatalogue.Sulfuras:
                    return new Sulfuras();
                case GildedRoseItemCatalogue.BackstagePasses:
                    return new BackstagePasses(item);
                case GildedRoseItemCatalogue.ConjuredManaCake:
                    return new ConjuredManaCake(item);
                default:
                    return new Basic(item);
            }
        }
    }
}