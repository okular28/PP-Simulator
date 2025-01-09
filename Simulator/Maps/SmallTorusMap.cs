using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    private readonly Rectangle board;
    public SmallTorusMap(int size){
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Mapa powinna mieć rozmiar od 5 do 20 punktów.");
        }
        Size = size;
        board = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    public override bool Exist(Point p)
    {
        return board.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        (int x, int y) = ((nextPoint.X + Size)% Size, (nextPoint.Y + Size) % Size);
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        (int x, int y) = ((nextPoint.X + Size) % Size, (nextPoint.Y + Size) % Size);
        return new Point(x, y);
    }
}
