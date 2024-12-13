using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
internal class Creature
{
    public string Name { get; } = "NoName";
    public int Level { get; set; } = 1;
    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }
    public Creature()
    {
    }
    public string Info => $"{Name} [{Level}]";
    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
}
