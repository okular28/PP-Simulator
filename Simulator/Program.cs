using System.ComponentModel;

namespace Simulator;
    internal class Program
    {
    static void Main(string[] args)
    {
        Console.WriteLine("Starting simulator!\n");
        var stwor = new Creature();
        stwor.SayHi();
        stwor.Level = 16;
        stwor.SayHi();
        Console.WriteLine(stwor.Info);
        Animals kot = new() { Description = "kot", Size = 16 };
        Console.WriteLine(kot.Info);
    }
}
