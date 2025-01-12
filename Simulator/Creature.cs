using System;
using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    private string name = "Unknown";
    private int level = 1;
    public Map? CurrentMap { get; private set; }
    public Point CreaturePosition {  get; set; }

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

    public void CreatureSpawner(Map map, Point p)
    {
        CurrentMap = map;
        CreaturePosition = p;
        map.Add(this, p);
    }

    public string Go(Direction direction)
    {
        CreaturePosition = CurrentMap.Next(CreaturePosition,direction);
        CurrentMap.Move(this, CreaturePosition);
        return $"{Name} goes {direction.ToString().ToLower()}";
    }
    public abstract string Info { get; }
    public abstract string Greeting();
    public abstract int Power { get; }
}
