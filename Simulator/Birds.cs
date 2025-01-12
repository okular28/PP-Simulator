using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    public bool Canfly = true;

    public override string Info
    {
        get
        {
            string WillItFly = Canfly ? "fly+" : "fly-";
            return $"{Description} ({WillItFly}) <{Size}>";
        }
    }
    public bool Flight
    {
        get
        {
            return Canfly;
        }
    }
    public Birds(string description, bool canFly) : base(description)
    {
        Canfly = canFly;
    }
    public override string Go(Direction direction)
    {
        if (Canfly)
        {
            CreaturePosition = CurrentMap.Next(CurrentMap.Next(CreaturePosition, direction), direction);
            CurrentMap.Move(this, CreaturePosition);
            return $"{Name} goes {direction.ToString().ToLower()}";
        }
        else
        {
            CreaturePosition = CurrentMap.NextDiagonal(CreaturePosition, direction);
            CurrentMap.Move(this, CreaturePosition);
            return $"{Name} goes {direction.ToString().ToLower()}";
        }

    }
}
