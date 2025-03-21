using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    internal class AttackItem(string name, int hit, int range)
    {
        public string Name { get; set; } = name;
        public int Hit { get; set; } = hit;
        public int Range { get; set; } = range;

    }
}
