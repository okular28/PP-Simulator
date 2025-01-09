using Simulator;
using Simulator.Maps;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting simulator!\n");
        //Lab4a();
        //Lab4b();
        //Lab5a();
        Lab5b();
        //Point p = new(10, 25);
        //Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        //Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
    }
    static void Lab5b()
    {
        try
        {
            Map map1 = new SmallSquareMap(20);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            Map map2 = new SmallSquareMap(40);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            Map map3 = new SmallSquareMap(-10);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            Map map4 = new SmallSquareMap(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Map map5 = new SmallSquareMap(15);
        Point point1 = new Point(4, 15);
        Point point2 = new Point(2, 10);
        Point point3 = new Point(2, -10);
        Point point4 = new Point(2, 0);
        Console.WriteLine(map5.Exist(point1));
        Console.WriteLine(map5.Exist(point2));
        Console.WriteLine(map5.Exist(point3));
        Console.WriteLine(map5.Exist(point4));
    }
    static void Lab5a()
    {
        Point point = new Point(5,2);
        Point point1 = new Point(4,6);
        Point point2 = new Point(5,4);
        Point point3 = new Point(15,15);
        try
        {
            //var f = new Rectangle(1,4,1,15);
            var d = new Rectangle(4, 5, 1, 6);
            Console.WriteLine(d.ToString());
            var x = new Rectangle(point,point1);
            Console.WriteLine(x.ToString());
            Console.WriteLine(x.Contains(point2));
            Console.WriteLine(x.Contains(point3));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.Greeting();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.Greeting();
            Console.WriteLine(o.ToString());
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.Greeting();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.Greeting();
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
    o,
    e,
    new Orc("Morgash", 3, 8),
    new Elf("Elandor", 5, 3)
};
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab4b()
    {
        object[] myObjects = {
    new Animals() { Description = "dogs"},
    new Birds { Description = "  eagles ", Size = 10 },
    new Elf("e", 15, -3),
    new Orc("morgash", 6, 4)
};
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
}
