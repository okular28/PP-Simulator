using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Orc : Creature
{
    private int rage;
    private int huntcounter = 0;
    public int Rage { get => rage; init
        {
            if (value < 1) rage = 1;
            else if (value > 10) rage = 10;
            else rage = value;
        }
    }
    public void Hunt()
    {
        huntcounter++;
        Console.WriteLine($"{Name} is hunting.");
        if (huntcounter == 2)
        {
            huntcounter = 0;
            if (Rage < 10)
            {
                rage++;
            }
        }
    }

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public Orc() { }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Rage}.");
    }
    public override int Power => (Level * 7) + (Rage * 3);
}
