using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public interface IMappable
    {
        void CreatureSpawner(Map map, Point p);
        string Go(Direction direction);
        string Name { get; init; }
        Point CreaturePosition { get; set; }
    }
}
