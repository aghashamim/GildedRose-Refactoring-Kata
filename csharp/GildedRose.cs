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
            // Go through each item
            foreach (var item in Items)
            {
                // When the item is of type Aged Brie
                if (item.Name == "Aged Brie")
                {
                    // and the quality is less than the maximum allowed of 50
                    if (item.Quality < 50)
                    {
                        // Increase the quality by 1
                        item.Quality = item.Quality + 1;
                    }

                    // and the sell in days have passed
                    if (item.SellIn <= 0)
                    {
                        // Decrease quality by 1
                        item.Quality = item.Quality + 1;
                    }

                    // Decrease the sell in days by 1
                    item.SellIn = item.SellIn - 1;
                }

                // When the item is of type Sulfuras
                else if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    // Do nothing, since it's a legendary item
                }

                // When the item is of type Backstage passes
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    // and the quality is less than the maximum allowed of 50
                    if (item.Quality < 50)
                    {
                        // Increase the quality by 1
                        item.Quality = item.Quality + 1;

                        // and there are 10 or less days remaining to sell
                        if (item.SellIn < 11)
                        {
                            // Increase the quality by 1
                            item.Quality = item.Quality + 1;
                        }

                        // and there are 5 or less days remaining to sell
                        if (item.SellIn < 6)
                        {
                            // Increase the quality by 1
                            item.Quality = item.Quality + 1;
                        }
                    }

                    // When the sell in days have passed
                    if (item.SellIn <= 0)
                    {
                        // Drop the quality to 0
                        item.Quality = item.Quality - item.Quality;
                    }

                    // Decrease the sell in days by 1
                    item.SellIn = item.SellIn - 1;
                }
                
                // When the item is of any other type
                else
                {
                    // When the quality is greater than 0
                    if (item.Quality > 0)
                    {
                        // Decrease quality by 1
                        item.Quality = item.Quality - 1;
                    }

                    // When the sell in days have passed
                    if (item.SellIn <= 0)
                    {
                        // Decrease quality by 1
                        item.Quality = item.Quality - 1;
                    }

                    // Decrease the sell in days by 1
                    item.SellIn = item.SellIn - 1;
                }
            }
        }
    }
}