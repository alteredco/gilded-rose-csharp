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
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                } 
                else if (item.Quality < 50)
                {
                    item.Quality ++;
                    if (item.Name.StartsWith("Backstage passes"))
                    {
                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.Quality +=1;
                        }

                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            item.Quality +=1;
                        }
                    }
                }
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn --;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality --;
                                }
                            }
                        }
                        else
                        {
                            item.Quality -= item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality ++;
                        }
                    }
                }
            }
        }
    }
}