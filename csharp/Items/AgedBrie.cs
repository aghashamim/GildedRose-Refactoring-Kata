namespace csharp.Items
{
    public class AgedBrie : IGuildedRoseItemQualityUpdateStrategy
    {
        private readonly Item item;
        public int QualityValueIncreaseNormal { get; protected set; } = 1;
        public int QualityValueIncreaseAfterExpiry { get; protected set; } = 2;
        public AgedBrie(Item item)
        {
            this.item = item;
        }
        public void UpdateQuality()
        {
            if (item.SellIn > 0)
            {
                item.Quality += QualityValueIncreaseNormal;
            }
            else
            {
                item.Quality += (QualityValueIncreaseNormal * QualityValueIncreaseAfterExpiry);
            }

            item.SellIn--;
        }
    }
}