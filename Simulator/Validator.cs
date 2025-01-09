using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value,int min, int max)
    {
        return Math.Clamp(value, min, max); ;
    }
    public static string Shortener(string name, int min, int max, char placeholder)
    {
        name = name.Trim();
        if (string.IsNullOrEmpty(name))
        {
            name = "Unknown";
        }
        else
        {
            if (name.Length < min)
            {
                name = name.PadRight(3, placeholder);
            }

            if (name.Length > max)
            {
                name = name.Substring(0, max).Trim();
                if (name.Length < min)
                {
                    name = name.PadRight(3, placeholder);
                }
            }

            if (char.IsLower(name[0]))
            {
                name = char.ToUpper(name[0]) + name.Substring(1);
            }
        }
        return name;
    }
}
