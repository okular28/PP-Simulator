using System.Data;
using System.Text;
using Simulator;
using Simulator.Maps;
namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
        SmallSquareMap map = new(16);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(7, 14), new(3, 7)];
        string moves = "durlrludlrurlldu";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();
            Console.WriteLine($"{simulation.CurrentCreature.Name} {simulation.CurrentCreature.CreaturePosition} goes {simulation.CurrentMoveName}:");
            simulation.Turn();
            mapVisualizer.Draw();
        }
    }
}
