using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
    public class SmallSquareMap : SmallMap
    {
        public SmallSquareMap(int Size) : base(Size, Size) { }
        //public readonly int Size;
        //private readonly Rectangle board;
        //public SmallSquareMap(int size)
        //{
        //    if(size < 5 || size > 20)
        //    {
        //        throw new ArgumentOutOfRangeException("Mapa powinna mieć rozmiar od 5 do 20 punktów.");
        //    }
        //    Size = size;
        //    board = new Rectangle(0, 0, Size-1, Size-1);
        //}

        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = p.Next(d);
            if (Exist(nextPoint))
            {
                return nextPoint;
            }
            return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextPoint = p.NextDiagonal(d);
            if (Exist(nextPoint))
                return nextPoint;
            return p;
        }
    }