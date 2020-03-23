using System.Collections.Generic;

namespace GildedRose
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
            foreach (var item in Items)
            {
                if (item.Name.StartsWith("Backstage passes"))
                { 
                    item.Quality =UpdateBackstagePassQuality(item);
                }
                else if (item.Name.StartsWith("Aged Brie")&& item.Quality <50)
                {
                    item.Quality += UpdateBrieQuality(item);
                } 
                else if (item.Name.StartsWith("Sulfuras"))
                {
                    item.Quality = 80;
                }
                else
                {
                    item.Quality += UpdateNormalItemQuality(item);
                }
                UpdateSellIn(item);
            }
        }
        
        private int UpdateSellIn(Item item)
        {
            if (item.Name.StartsWith("Sulfuras"))
            {
                return item.SellIn;
            }
            else
            {
                return item.SellIn--;
            }
        }

        private int UpdateBrieQuality(Item item)
        {
            return item.SellIn < 0 ? 2 : 1;
        }

        private int UpdateBackstagePassQuality(Item item)
        {
            if (item.SellIn <=10)
            {
                if (item.SellIn <= 5 && item.SellIn > 0)
                {
                    return item.Quality += 3;
                } 
                else if (item.SellIn <= 0)
                {
                    return item.Quality = 0;
                }
                
                return item.Quality += 2;
            }
            else if(item.Quality <50)
            {
                return item.Quality++;
            }
            else
            {
                return item.Quality;
            }
        }
        
        private int UpdateNormalItemQuality(Item item)
        {
            if (item.Quality > 0)
            {
                return -1;
            }
            else
            {
                return item.Quality;
            }
        }
    }
}