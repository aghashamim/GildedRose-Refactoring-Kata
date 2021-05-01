using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var lowestPossibleQualityValue = GildedRoseItemCatalogue.GetLowestPossibleQualityValue();
            foreach (var item in Items)
            {
                CustomisedItemFactory.Create(item).UpdateQuality();
                var highestPossibleQualityValueForItem = GildedRoseItemCatalogue.GetHighestPossibleQualityValueForItem(item);
                if (item.Quality < lowestPossibleQualityValue)
                {
                    item.Quality = lowestPossibleQualityValue;
                }
                else if (item.Quality > highestPossibleQualityValueForItem)
                {
                    item.Quality = highestPossibleQualityValueForItem;
                }
            }
        }
    }
}