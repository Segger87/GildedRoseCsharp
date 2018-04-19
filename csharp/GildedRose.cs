using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public bool QualityLessThan50(Item item)
        {
            return item.Quality < 50;
        }

        public int QualityMinus1(Item item)
        {
            return item.Quality = item.Quality - 1;
        }
        public int BackstagePasses(Item item)
        {
            if (item.SellIn < 11)
            {
                if (QualityLessThan50(item))
                {
                    item.Quality = item.Quality + 1;
                    return item.Quality;
                }
            }

            if (item.SellIn < 6)
            {
                if (QualityLessThan50(item))
                {
                    item.Quality = item.Quality + 1;
                    return item.Quality;
                }
            }

            return item.Quality;
        }


        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            QualityMinus1(Items[i]);
                        }
                    }
                }
                else
                {
                    if (QualityLessThan50(Items[i]))
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            BackstagePasses(Items[i]);
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    switch (Items[i].Name)
                    {
                        case "Aged Brie":
                            if (QualityLessThan50(Items[i]))
                            {
                                Items[i].Quality++;
                            }
                            break;
                        case "Backstage passes to a TAFKAL80ETC concert":
                            Items[i].Quality = 0;
                            break;
                        case "Sulfuras, Hand of Ragnaros":
                            // Do nothing
                            break;
                        default:
                            if (Items[i].Quality > 0)
                            {
                                QualityMinus1(Items[i]);
                            }
                            break;
                    }
                }
            }
        }
    }
}
