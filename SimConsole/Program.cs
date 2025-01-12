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
        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits"), new Birds("Emus", false), new Birds("Eagles", true)];
        List<Point> points = [new(0, 1), new(0, 2), new(0,3), new(0,4), new(0,5)];
        string moves = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";

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
