using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    internal class DefenseItem(string name, int reduceHitPoint)
    {
        public string Name { get; set; } = name;
        public int ReduceHitPoint { get; set; } = reduceHitPoint;
    }
}
