using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            // Go through each item
            foreach (var item in Items)
            {
                // For items of type other than Aged Brie and Backstage passes
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    // When the quality is greater than 0
                    if (item.Quality > 0)
                    {
                        // and item type is other than Sulfuras
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            // Decrease quality by 1
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                // For items of type Aged Brie and Backstage passes
                else
                {
                    // When the quality is less than the maximum allowed of 50
                    if (item.Quality < 50)
                    {
                        // Increase the quality by 1
                        item.Quality = item.Quality + 1;

                        // When the item is of type Backstage passes
                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            // and there are 10 or less days remaining to sell
                            if (item.SellIn < 11)
                            {
                                // and the quality is less than the maximum allowed of 50
                                if (item.Quality < 50)
                                {
                                    // Increase the quality by 1
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            // and there are 5 or less days remaining to sell
                            if (item.SellIn < 6)
                            {
                                // and the quality is less than the maximum allowed of 50
                                if (item.Quality < 50)
                                {
                                    // Increase the quality by 1
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                // For items of type other than Sulfuras
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    // Decrease the sell in days by 1
                    item.SellIn = item.SellIn - 1;
                }

                // When the sell in days have passed
                if (item.SellIn < 0)
                {
                    // For items of type other than Aged Brie
                    if (item.Name != "Aged Brie")
                    {
                        // and items of type other than Backstage passes
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            // When the quality is greater than 0
                            if (item.Quality > 0)
                            {
                                // and the item type is other than Sulfuras
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    // Decrease quality by 1
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        // For item of type Backstage passes
                        else
                        {
                            // Drop the quality to 0
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    // For item of type Aged Brie
                    else
                    {
                        // When the quality is less than the maximum allowed of 50
                        if (item.Quality < 50)
                        {
                            // Increase the quality by 1
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}