
using CachingDecorator;

class Worker
{
    public int Slow0()
    {
        Console.WriteLine("Called");
        return 0;
    }

    public int Slow1(int min)
    {
        Console.WriteLine($"Called with {min}");
        return min;
    }

    public int Slow2(int min, int max)
    {
        Console.WriteLine($"Called with {min},{max}");
        return min + max;
    }

    public int Slow3(int min, int max, int max2)
    {
        Console.WriteLine($"Called with {min},{max},{max2}");
        return min + max + max2;
    }

    public string Slow4(string a1, int a2, float a3)
    {
        Console.WriteLine($"Called with {a1}, {a2}, {a3}");

        return a1 + " " + a2 + " " + a3;
    }
}

class Program
{
    static void Main()
    {
        var worker = new Worker();

        var decoratedSlow0 = Decorators.Caching(worker.Slow0);

        Console.WriteLine(decoratedSlow0()); // works
        Console.WriteLine("Again " + decoratedSlow0()); // same (cached)
        Console.WriteLine();

        var decoratedSlow1 = Decorators.Caching<int, int>(worker.Slow1);

        Console.WriteLine(decoratedSlow1(1)); // works
        Console.WriteLine("Again " + decoratedSlow1(1)); // same (cached)
        Console.WriteLine();

        var decoratedSlow2 = Decorators.Caching<int, int, int>(worker.Slow2);

        Console.WriteLine(decoratedSlow2(2, 2)); // works
        Console.WriteLine("Again " + decoratedSlow2(2, 2)); // same (cached)
        Console.WriteLine();

        var decoratedSlow3 = Decorators.Caching<int, int, int, int>(worker.Slow3);

        Console.WriteLine(decoratedSlow3(3, 3, 3)); // works
        Console.WriteLine("Again " + decoratedSlow3(3, 3, 3)); // same (cached)
        Console.WriteLine();

        var decoratedSlow4 = Decorators.Caching<string, int, float, string>(worker.Slow4);

        Console.WriteLine(decoratedSlow4("sdsdds", 3, 3.4f)); // works

        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine("Again " + decoratedSlow4("sdsdds", 3, 3.4f)); // same (cached)
        Console.WriteLine();
    }
}
