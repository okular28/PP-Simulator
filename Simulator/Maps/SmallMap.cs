using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallMap : Map
{

    public readonly int Sizex;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) {
        if (sizeX > 20 || sizeY > 20)
        {
            throw new ArgumentOutOfRangeException("Mapa powinna mieć rozmiar maksymalnie 20x20.");
        }
    }

    public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    }
}
