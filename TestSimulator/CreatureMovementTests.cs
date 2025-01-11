using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class CreatureMovementTests
{
    [Fact]
    public void Creature_CanMoveToNewPosition()
    {
        // Arrange
        var map = new SmallTorusMap(10, 10);
        var creature = new Orc("Gorbag", 5);
        var initialPosition = new Point(9, 2);
        var direction = Direction.Right;

        creature.CreatureSpawner(map, initialPosition);

        creature.Go(direction);

        // Assert
        var expectedPosition = new Point(0, 2);
        Assert.Equal(expectedPosition, creature.CreaturePosition);
        Assert.Equal(expectedPosition, map.CreaturePositionDictionary[creature]);
    }
}
