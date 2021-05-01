using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void When_A_Day_Has_Passed_Then_SellIn_Value_Has_Decreased()
        {
            var item = ExecuteUpdateOnASingleItem("+5 Dexterity Vest", 10, 20);
            Assert.AreEqual(9, item.SellIn);
        }

        [Test]
        public void When_A_Day_Has_Passed_Then_Quality_Value_Has_Decreased()
        {
            var item = ExecuteUpdateOnASingleItem("+5 Dexterity Vest", 10, 20);
            Assert.AreEqual(19, item.Quality);
        }

        [Test]
        public void When_Sell_By_Date_Has_Passed_Then_Quality_Value_Decreases_Twice_As_Fast()
        {
            var item = ExecuteUpdateOnASingleItem("+5 Dexterity Vest", 0, 20);
            Assert.AreEqual(18, item.Quality);
        }

        [Test]
        public void When_The_Quality_Of_An_Item_Has_Reached_Zero_Then_Quality_Value_Does_Not_Decrease_Any_Further()
        {
            var item = ExecuteUpdateOnASingleItem("+5 Dexterity Vest", 10, 0);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Aged_Brie_Then_Quality_Value_Increases()
        {
            var item = ExecuteUpdateOnASingleItem("Aged Brie", 2, 0);
            Assert.AreEqual(1, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Aged_Brie_And_Sell_By_Date_Has_Passed_Then_Quality_Value_Increases_Twice_As_Fast()
        {
            var item = ExecuteUpdateOnASingleItem("Aged Brie", 0, 20);
            Assert.AreEqual(22, item.Quality);
        }

        [Test]
        public void When_The_Quality_Of_An_Item_Has_Reached_Fifty_Then_Quality_Value_Does_Not_Increase_Any_Further()
        {
            var item = ExecuteUpdateOnASingleItem("Aged Brie", 10, 50);
            Assert.AreEqual(50, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Sulfuras_Then_SellIn_Value_Remains_Unchanged()
        {
            var item = ExecuteUpdateOnASingleItem("Sulfuras, Hand of Ragnaros", 2, 80);
            Assert.AreEqual(2, item.SellIn);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Sulfuras_Then_Quality_Value_Remains_Unchanged()
        {
            var item = ExecuteUpdateOnASingleItem("Sulfuras, Hand of Ragnaros", 2, 80);
            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Backstage_Passes_Then_Quality_Value_Increases()
        {
            var item = ExecuteUpdateOnASingleItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
            Assert.AreEqual(21, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Backstage_Passes_And_SellIn_Days_Are_Equal_To_Ten_Then_Quality_Value_Increases_Twice_As_Fast()
        {
            var item = ExecuteUpdateOnASingleItem("Backstage passes to a TAFKAL80ETC concert", 10, 48);
            Assert.AreEqual(50, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Backstage_Passes_And_SellIn_Days_Are_Less_Than_Ten_Then_Quality_Value_Increases_Twice_As_Fast()
        {
            var item = ExecuteUpdateOnASingleItem("Backstage passes to a TAFKAL80ETC concert", 9, 48);
            Assert.AreEqual(50, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Backstage_Passes_And_SellIn_Days_Are_Equal_To_Five_Then_Quality_Value_Increases_Thrice_As_Fast()
        {
            var item = ExecuteUpdateOnASingleItem("Backstage passes to a TAFKAL80ETC concert", 5, 47);
            Assert.AreEqual(50, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Backstage_Passes_And_SellIn_Days_Are_Less_Than_Five_Then_Quality_Value_Increases_Thrice_As_Fast()
        {
            var item = ExecuteUpdateOnASingleItem("Backstage passes to a TAFKAL80ETC concert", 4, 47);
            Assert.AreEqual(50, item.Quality);
        }

        [Test]
        public void When_The_Type_Of_Item_Is_Backstage_Passes_And_SellIn_Days_Are_Less_Than_Zero_Then_Quality_Value_Drops_To_Zero()
        {
            var item = ExecuteUpdateOnASingleItem("Backstage passes to a TAFKAL80ETC concert", -1, 47);
            Assert.AreEqual(0, item.Quality);
        }

        private Item ExecuteUpdateOnASingleItem(string itemName, int sellIn, int quality)
        {
            var item = new Item { Name = itemName, SellIn = sellIn, Quality = quality };
            IList<Item> Items = new List<Item> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            return Items.First();
        }
    }
}