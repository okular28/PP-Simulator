using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Simulator.Maps;

namespace Simulator
{
    public class Animals : IMappable
    {

        public string Description { get; init; }
        public string Name { get; set; }
        public Map? CurrentMap { get; private set; }
        public Point CreaturePosition { get; set; }

        public Animals(string description)
        {
            Name = description;
            Description = Validator.Shortener(description, 3, 15, '#');
        }
        //public required string Description {
        //    get => description;
        //    init 
        //    {
        //        description = Validator.Shortener(value, 3, 15, '#');
        //    } 
        //}
        public uint Size { get; set; } = 3;
        public virtual string Info => $"{Description} <{Size}>";

        public virtual void CreatureSpawner(Map map, Point p)
        {
            CurrentMap = map;
            CreaturePosition = p;
            map.Add(this, p);
        }

        public virtual string Go(Direction direction)
        {
            CreaturePosition = CurrentMap.Next(CreaturePosition, direction);
            CurrentMap.Move(this, CreaturePosition);
            return $"{Name} goes {direction.ToString().ToLower()}";
        }
        public override string ToString()
        {
            return GetType().Name.ToUpper() + $": {Info}";
        }
    }
}
