using System.Collections.Generic;
using FluentAssertions;
using GildedRose;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class UnitTests
    {
        [Test]
        public void ItemsDecreaseQualityByOneEachDayIfNotSpecial()
        {
            //given
            var item = new Item
            {
                Name = "testItem",
                SellIn = 5,
                Quality = 30
            };

            var itemList = new List<Item> {item};
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();
            
            itemList[0].Should().BeEquivalentTo(new Item{ Name = "testItem", SellIn = 4, Quality = 29});
        }
        
        [Test]
        public void SpecialItemsExceptSulfurasMaxQualityIsFifty()
        {
            //given
            
            var itemList = new List<Item>
            { 
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = 50
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 8,
                    Quality = 50
                },
                
            };
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();
            
            itemList[0].Should().BeEquivalentTo(new Item {Name = "Aged Brie", SellIn = 0, Quality = 50});
            itemList[1].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 50});
            
        }
        
        [Test]
        public void SpecialItemsExceptSulfurasWithQualityLessThanFiftyIncreaseQualityEachDay()
        {
            //given
            
            var itemList = new List<Item>
            { 
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = 39
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 20,
                    Quality = 24
                },
                
            };
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();
            
            itemList[0].Should().BeEquivalentTo(new Item {Name = "Aged Brie", SellIn = 0, Quality = 40});
            itemList[1].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 19, Quality = 25});
            
        }
        
        [Test]
        public void BackstagePassesWithSellInBetweenTenAndFiveAndQualityUnderFiftyIncreaseByTwo()
        {
            //given
            
            var itemList = new List<Item>
            { 
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 3
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 6,
                    Quality = 17
                },
            };
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();

            itemList[0].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 5});
            itemList[1].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 19});
            
        }
        
        [Test]
        public void BackstagePassesWithSellInBetweenFiveAndZeroAndQualityUnderFiftyIncreaseByThree()
        {
            //given
            
            var itemList = new List<Item>
            { 
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 3
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = 17
                },
            };
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();

            itemList[0].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 6});
            itemList[1].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20});
            
        }
        
        [Test]
        public void BackstagePassesWithSellInBelowZeroDropQualityToZero()
        {
            //given
            
            var itemList = new List<Item>
            { 
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 3
                }
            };
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();

            itemList[0].Should().BeEquivalentTo(new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0});
        }
        
        [Test]
        public void SulfurasSellInAndQualityDoNotChange()
        {
            //given
            
            var itemList = new List<Item>
            { 
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}
            };
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();
            
            itemList[0].Should().BeEquivalentTo(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80});
            itemList[1].Should().BeEquivalentTo(new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80});
            
        }
        
        [Test]
        public void BackStagePassIncreaseByOneIfMoreThanTenDaysLeft()
        {
            //given
            var pass = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            };

            var itemList = new List<Item> {pass};
            
            //when
            var gildedRose = new GildedRose.GildedRose(itemList);
            //then
            
            gildedRose.UpdateQuality();
            
            itemList[0].Should().BeEquivalentTo(new Item{ Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21});
        }
    }
}