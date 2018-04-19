using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace csharp
{
    public class GildedRose
    {
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string AgedBrie = "Aged Brie";
        public const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        public const string ConjouredRabbit = "Conjoured rabbit";

        IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public bool QualityLessThan50(Item item)
        {
            return item.Quality < 50;
        }

        public int QualityMinus1(Item item)
        {
            return item.Quality = item.Quality - 1;
        }

        public int AgedBrieQuality(Item item)
        {
            if (QualityLessThan50(item))
            {
                return item.Quality++;
            }

            return item.Quality;
        }

        public int BackstagePassesQuality(Item item)
        {
            if (item.SellIn < 11)
            {
                if (QualityLessThan50(item))
                {
                    return item.Quality++;
                }
            }

            if (item.SellIn < 6)
            {
                if (QualityLessThan50(item))
                {
                    return item.Quality++;
                }
            }

            return item.Quality;
        }

        public void SellInItemsBelow0(Item item)
        {
            switch (item.Name)
            {
                case AgedBrie:
                    AgedBrieQuality(item);
                    break;
                case BackstagePasses:
                    item.Quality = 0;
                    break;
                case SulfurasHandOfRagnaros:
                    // Do nothing
                    break;
                default:
                    if (item.Quality > 0)
                    {
                        QualityMinus1(item);
                    }
                    break;
            }
        }


        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == AgedBrie)
                {
                    AgedBrieQuality(Items[i]);
                }

                if (Items[i].Name == BackstagePasses)
                {
                    AgedBrieQuality(Items[i]);
                    BackstagePassesQuality(Items[i]);
                }

                if (Items[i].Name != AgedBrie && Items[i].Name != BackstagePasses)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != SulfurasHandOfRagnaros)
                        {
                            QualityMinus1(Items[i]);
                        }
                    }
                }

                if (Items[i].Name != SulfurasHandOfRagnaros)
                {
                    Items[i].SellIn--;
                }

                if (Items[i].SellIn < 0)
                {
                    SellInItemsBelow0(Items[i]);
                }
            }
        }
    }
}
