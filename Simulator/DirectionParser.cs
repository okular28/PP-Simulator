using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        List<Direction> DirectionList = new List<Direction>();
        foreach (char letter in input)
        {
            switch (letter)
            {
                case 'U':
                case 'u':
                    DirectionList.Add(Direction.Up);
                    break;
                case 'R':
                case 'r':
                    DirectionList.Add(Direction.Right);
                    break;
                case 'D':
                case 'd':
                    DirectionList.Add(Direction.Down);
                    break;
                case 'L':
                case 'l':
                    DirectionList.Add(Direction.Left);
                    break;
            }
        }
        return DirectionList.ToArray();
    }
}
