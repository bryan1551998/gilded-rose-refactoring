using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> Items;

    public GildedRose(IList<Item> items)
    {
        Items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            if (item.Name == "Aged Brie")
            {
                UpdateAgedBrie(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePass(item);
            }
            else
            {
                UpdateNormalItem(item);
            }

            item.SellIn--;
        }
    }

    private void UpdateNormalItem(Item item)
    {
        var amount = IsConjured(item) ? 2 : 1;

        if (item.SellIn <= 0)
        {
            amount *= 2;
        }

        DecreaseQuality(item, amount);
    }

    private void UpdateAgedBrie(Item item)
    {
        IncreaseQuality(item);

        if (item.SellIn <= 0)
        {
            IncreaseQuality(item);
        }
    }

    private void UpdateBackstagePass(Item item)
    {
        if (item.SellIn <= 0)
        {
            item.Quality = 0;
            return;
        }

        IncreaseQuality(item);

        if (item.SellIn <= 10)
        {
            IncreaseQuality(item);
        }

        if (item.SellIn <= 5)
        {
            IncreaseQuality(item);
        }
    }

    private void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }

    private void DecreaseQuality(Item item, int amount)
    {
        item.Quality = Math.Max(0, item.Quality - amount);
    }

    private bool IsConjured(Item item)
    {
        return item.Name.Contains("Conjured", StringComparison.OrdinalIgnoreCase);
    }
}