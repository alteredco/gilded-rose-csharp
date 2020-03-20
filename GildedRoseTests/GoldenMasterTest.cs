using System.Collections.Generic;
using NUnit.Framework;
using FakeItEasy;
using FluentAssertions;
using GildedRose;


namespace GildedRoseTests
{
    public class ItemListTests
    {
        [Test]
        public void UpdateItemQualityInItemList()
        {
            IList<Item> itemList = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                }
            };

            var gildedRose = new GildedRose.GildedRose(itemList);

           for (var i = 0; i < 10; i++)
           {
               gildedRose.UpdateQuality();
           }
           
           itemList[0].Should().BeEquivalentTo(new Item{Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10});
           itemList[1].Should().BeEquivalentTo(new Item{Name = "Aged Brie", SellIn = -8, Quality = 18});
           itemList[2].Should().BeEquivalentTo(new Item {Name = "Elixir of the Mongoose", SellIn = -5, Quality = 0});
           itemList[3].Should().BeEquivalentTo(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80});
           itemList[4].Should().BeEquivalentTo(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80});
           itemList[5].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 35});
           itemList[6].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50});
           itemList[7].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -5, Quality = 0});
        }
    }
}