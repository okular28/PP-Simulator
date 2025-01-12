using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;
    public MapVisualizer(Map map)
    {
        _map = map;
    }
    public void Draw()
    {
        int width = _map.SizeX;
        int height = _map.SizeY;

        Console.Write(Box.TopLeft);
        for (int i = 0; i < width; i++)
        {
            Console.Write(Box.Horizontal);
            if (i != width - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int j = 0; j < height; j++)
        {
            Console.Write(Box.Vertical);
            for (int i = 0; i < width; i++)
            {
                var creatures = _map.At(i, j);
                if (creatures.Count > 1)
                {
                    Console.Write("X");
                }
                else if (creatures.Count == 1)
                {
                    switch (creatures[0])
                    {
                        case Orc:
                            Console.Write('O'); break;
                        case Elf:
                            Console.Write('E'); break;
                    }
                }
                else Console.Write(" ");

                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (j != height - 1)
            {
                Console.Write(Box.MidLeft);
                for (int i = 0; i < width; i++)
                {
                    Console.Write(Box.Horizontal);
                    if (i != width - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int i = 0; i < width; i++)
        {
            Console.Write(Box.Horizontal);
            if (i != width - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }

}