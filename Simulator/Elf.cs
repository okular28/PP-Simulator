using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    internal class Elf : Creature
    {
        private int singcounter = 0;
        private int agility;
        public int Agility { get => agility; init
            {
                if (value < 1) agility = 1;
                else if (value > 10) agility = 10;
                else agility = value;
            }
        }
        public void Sing()
        {
            singcounter++;
            Console.WriteLine($"{Name} is singing.");
            if (singcounter == 3)
            {
                singcounter = 0;
                if (Agility < 10)
                {
                    agility++;
                }
            }
        }

        public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }
        public Elf() { }
        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }
        public override int Power => (Level * 8) + (Agility * 2);
    }
}
