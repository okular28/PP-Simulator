using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int turnIndex = 0;
    private int moveIndex = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature { 
        get
        {
            return Creatures[turnIndex% Creatures.Count];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName {
        get
        {
            string currentMove = Moves[moveIndex%Moves.Length].ToString().ToLower();
            return currentMove;
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures.Count == 0 || creatures == null)
        {
            throw new ArgumentNullException("Lista stworów jest pusta");
        }
        if (positions.Count != creatures.Count)
        {
            throw new ArgumentException("Liczba stworów różni się od liczby pozycji startowych");
        }
        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;
        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].CreatureSpawner((SmallMap)Map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() { 
        if (Finished)
        {
            throw new InvalidOperationException("Symulacja zakończona");
        }
        Creature creature = CurrentCreature;
        string move = Moves[moveIndex%Moves.Length].ToString();
        creature.Go(DirectionParser.Parse(move)[0]);
        turnIndex++;
        moveIndex++;
        if (moveIndex >= Moves.Length)
        {
            moveIndex = 0;
        }
        if (turnIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}