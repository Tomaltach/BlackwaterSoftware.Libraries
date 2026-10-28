// See https://aka.ms/new-console-template for more information
using BlackwaterSoftware.CountryCatalog;
using BlackwaterSoftware.Extensions;

Console.WriteLine("Hello, World!");

TestCountry();
TestExtensions();

Console.ReadLine();

static void TestCountry()
{
    var groups = Countries.ByContinentAndRegion;
    foreach (var continent in groups)
    {
        PrintHeader(continent.Key.ToString(), 1);
        foreach (var region in continent.Value)
        {
            PrintHeader(region.Key.ToString(), 2);
            foreach (var country in region.Value)
            {
                Console.WriteLine(country.Name);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
static void TestExtensions()
{
    var indexedCountries = Countries.All.WithIndex();
    foreach (var pair in indexedCountries)
        Console.WriteLine($"-> {pair.Index,3}, {pair.Item.Name}");
    Console.WriteLine();

    var index = Countries.All.IndexOf(x => x.Iso2 == "IE");
    Console.WriteLine(index);
}

static void PrintHeader(string title, int level)
{
    var formattedTitle = $" [{title}] ";

    int totalWidth = Console.WindowWidth;
    int remaining = totalWidth - formattedTitle.Length;

    if (remaining < 0)
    {
        Console.WriteLine(formattedTitle);
        return;
    }

    int left = remaining / 2;
    int right = remaining - left;
    var symbol = level switch
    {
        1 => '=',
        2 => '-',
        _ => '#',
    };
    Console.WriteLine($"{new string(symbol, left)}{formattedTitle}{new string(symbol, right)}");
}