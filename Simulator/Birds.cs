using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    public bool Canfly = true;
    public override string Info
    {
        get
        {
            string WillItFly = Canfly ? "fly+" : "fly-";
            return$"{Description} ({WillItFly}) <{Size}>";
        }
    }

}
