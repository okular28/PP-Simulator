using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallMap : Map
{
    public readonly int Sizex;
    public Dictionary<object, Point> CreaturePositionDictionary { get; }
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) {
        if (sizeX > 20 || sizeY > 20)
        {
            throw new ArgumentOutOfRangeException("Mapa powinna mieć rozmiar maksymalnie 20x20.");
        }
        CreaturePositionDictionary = new Dictionary<object, Point>();
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
    public bool CreatureChecker(object Creature)
    {
        return CreaturePositionDictionary.ContainsKey(Creature);
    }
    public List<object> At(Point p)
    {
        return CreaturePositionDictionary
        .Where(kvp => kvp.Value.Equals(p))
        .Select(kvp => kvp.Key)
        .ToList();
    }

    public List<object> At(int x, int y)
    {
        // Tworzymy punkt na podstawie współrzędnych i wywołujemy poprzednią wersję metody.
        return At(new Point(x, y));
    }
    public void Add(object Creature, Point p)
    {
        if (!CreatureChecker(Creature))
        {
            CreaturePositionDictionary.Add(Creature, p);
        }
    }
    public void Remove(object Creature)
    {
        if (CreatureChecker(Creature))
        {
            CreaturePositionDictionary.Remove(Creature);
        }
    }
    public override void Move(object creature, Point p)
    {
        if (CreatureChecker(creature))
        {
            CreaturePositionDictionary[creature] = p;
        }
    }
}
