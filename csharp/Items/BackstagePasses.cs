namespace csharp.Items
{
    public class BackstagePasses : IGuildedRoseItemQualityUpdateStrategy
    {
        private readonly Item item;
        public int QualityValueIncreaseNormal { get; protected set; } = 1;
        public int QualityValueIncreaseMoreThanFiveDays { get; protected set; } = 2;
        public int QualityValueIncreaseLessThanFiveDays { get; protected set; } = 3;
        public BackstagePasses(Item item)
        {
            this.item = item;
        }

        public void UpdateQuality()
        {
            if (item.SellIn > 10)
            {
                item.Quality += QualityValueIncreaseNormal;
            }

            else if (item.SellIn > 5)
            {
                item.Quality += QualityValueIncreaseMoreThanFiveDays;
            }

            else if (item.SellIn > 0)
            {
                item.Quality += QualityValueIncreaseLessThanFiveDays;
            }

            else
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }
    }
}