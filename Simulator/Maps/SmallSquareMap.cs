using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
    public class SmallSquareMap : SmallMap
    {
        public SmallSquareMap(int Size) : base(Size, Size) { }

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