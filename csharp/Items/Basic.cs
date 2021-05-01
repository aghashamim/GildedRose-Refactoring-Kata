namespace csharp.Items
{
    public class Basic : IGuildedRoseItemQualityUpdateStrategy
    {
        private readonly Item item;
        public int QualityValueDecreaseNormal { get; protected set; } = 1;
        public int QualityValueDescreaseAfterExpiry { get; protected set; } = 2;

        public Basic(Item item)
        {
            this.item = item;
        }
        public void UpdateQuality()
        {
            if (item.SellIn > 0)
            {
                item.Quality -= QualityValueDecreaseNormal;
            }
            else
            {
                item.Quality -= (QualityValueDecreaseNormal * QualityValueDescreaseAfterExpiry);
            }

            item.SellIn--;
        }
    }
}