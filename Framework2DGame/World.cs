using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    public class World(int maxX, int maxY)
    {
        public int MaxX { get; set; } = maxX;
        public int MaxY { get; set; } = maxY;
    }
}
