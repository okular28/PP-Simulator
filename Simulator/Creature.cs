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


    public string Go(Direction direction)
    {
        return $"{Name} goes {direction.ToString().ToLower()}";
    }
    public string[] Go(Direction[] directions)
    {
        List<string> results = new List<string>();
        foreach (Direction d in directions)
        {
            results.Add(Go(d));
        }
       return results.ToArray();
    }

    public string[] Go(string directions)
    {
        return Go(DirectionParser.Parse(directions));
    }
    public abstract string Info { get; }
    public abstract string Greeting();
    public abstract int Power { get; }
    public override string ToString()
    {
        return GetType().Name.ToUpper() + $": {Info}";
    }
}
