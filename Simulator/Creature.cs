using System;

namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    public int Level
    {
        get => level;
        init
        {
            level = Validator.Limiter(value, 0, 10);
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }


    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }


    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    }
    public void Go(Direction[] directions)
    {
        foreach(Direction d in directions)
        {
            Go(d);
        }
    }

    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }
    public abstract string Info { get; }
    public abstract void SayHi();
    public abstract int Power { get; }
    public override string ToString()
    {
        return GetType().Name.ToUpper() + $": {Info}";
    }
}
