using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base (sizeX, sizeY)
    {
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        (int x, int y) = ((nextPoint.X + SizeX) % SizeX, (nextPoint.Y + SizeY) % SizeY);
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        (int x, int y) = ((nextPoint.X + SizeX) % SizeX, (nextPoint.Y + SizeY) % SizeY);
        return new Point(x, y);
    }
}
