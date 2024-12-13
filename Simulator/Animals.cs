using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    internal class Animals
    {
        private string description = "Unknown";
        public required string Description {
            get => description;
            init 
            {
                description = value.Trim();
                if (string.IsNullOrEmpty(description))
                {
                    description = "Unknown";
                }

                if (description.Length < 3)
                {
                    description = description.PadRight(3, '#');
                }

                if (description.Length > 15)
                {
                    description = description.Substring(0, 15).Trim();

                }

                if (char.IsLower(description[0]))
                {
                    description = char.ToUpper(description[0]) + description.Substring(1);
                }
            } }
        public uint Size { get; set; } = 3;
        public string Info => $"{Description} <{Size}>";
    }
}
