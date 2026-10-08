using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class ArticuloNormalTests
{
    [Fact(DisplayName = """
        GIVEN un artículo normal con 10 días restantes y Quality 5
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality disminuye en 1
        """)]
    public void DisminuyeLaCalidadEnUno()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item { Name = "foo", SellIn = 10, Quality = 5 }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal("foo", items[0].Name);
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(4, items[0].Quality);
    }

    [Fact(DisplayName = """
        GIVEN un artículo normal con SellIn 0 y Quality 5
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality disminuye en 2
        """)]
    public void UnaVezCaducadoDisminuyeLaCalidadEnDos()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item { Name = "foo", SellIn = 0, Quality = 5 }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(3, items[0].Quality);
    }

    [Fact(DisplayName = """
        GIVEN un artículo normal con Quality 0
        WHEN actualizamos el inventario
        THEN Quality no puede ser negativa
        """)]
    public void LaCalidadNoPuedeSerNegativa()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item { Name = "foo", SellIn = 10, Quality = 0 }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(0, items[0].Quality);
    }
}

public class AgedBrieTests
{
    [Fact(DisplayName = """
        GIVEN un Aged Brie con 10 días restantes y Quality 5
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality aumenta en 1
        """)]
    public void AumentaLaCalidadEnUno()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(6, items[0].Quality);
    }

    [Fact(DisplayName = """
        GIVEN un Aged Brie con SellIn 0 y Quality 5
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality aumenta en 2
        """)]
    public void UnaVezCaducadoAumentaLaCalidadEnDos()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 5 }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(7, items[0].Quality);
    }
}

public class CalidadTests
{
    [Fact(DisplayName = """
        GIVEN un Aged Brie con Quality 50
        WHEN actualizamos el inventario
        THEN Quality no puede superar 50
        """)]
    public void LaCalidadNoPuedeSuperarCincuenta()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(50, items[0].Quality);
    }
}

public class SulfurasTests
{
    [Fact(DisplayName = """
        GIVEN un Sulfuras con SellIn 10 y Quality 80
        WHEN actualizamos el inventario
        THEN SellIn y Quality permanecen sin cambios
        """)]
    public void NoSeModifica()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 10,
                Quality = 80
            }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(10, items[0].SellIn);
        Assert.Equal(80, items[0].Quality);
    }
}

public class BackstagePassTests
{
    [Fact(DisplayName = """
        GIVEN una entrada Backstage con más de 10 días para el concierto
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality aumenta en 1
        """)]
    public void ConMasDeDiezDiasAumentaLaCalidadEnUno()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 5
            }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(14, items[0].SellIn);
        Assert.Equal(6, items[0].Quality);
    }

    [Fact(DisplayName = """
        GIVEN una entrada Backstage con 10 días para el concierto
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality aumenta en 2
        """)]
    public void ConDiezDiasOMenosAumentaLaCalidadEnDos()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 5
            }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(7, items[0].Quality);
    }

    [Fact(DisplayName = """
        GIVEN una entrada Backstage con 5 días para el concierto
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality aumenta en 3
        """)]
    public void ConCincoDiasOMenosAumentaLaCalidadEnTres()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 5
            }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(4, items[0].SellIn);
        Assert.Equal(8, items[0].Quality);
    }

    [Fact(DisplayName = """
        GIVEN una entrada Backstage con SellIn 0
        WHEN actualizamos el inventario
        THEN Quality pasa a 0
        """)]
    public void UnaVezPasadoElConciertoLaCalidadPasaACero()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 20
            }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }
}

public class ConjuredTests
{
    [Fact(DisplayName = """
        GIVEN un artículo Conjured con 10 días restantes y Quality 5
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality disminuye en 2
        """)]
    public void DisminuyeLaCalidadEnDos()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 10,
                Quality = 5
            }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(9, items[0].SellIn);
        Assert.Equal(3, items[0].Quality);
    }

    [Fact(DisplayName = """
        GIVEN un artículo Conjured con SellIn 0 y Quality 10
        WHEN actualizamos el inventario
        THEN SellIn disminuye en 1 y Quality disminuye en 4
        """)]
    public void UnaVezCaducadoDisminuyeLaCalidadEnCuatro()
    {
        // GIVEN
        IList<Item> items = new List<Item>
        {
            new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 0,
                Quality = 10
            }
        };

        var app = new GildedRose(items);

        // WHEN
        app.UpdateQuality();

        // THEN
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(6, items[0].Quality);
    }
}
