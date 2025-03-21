using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    public class WorldObject(string name, bool lootable, bool removable)
    {
        public string Name { get; set; } = name;
        public bool Lootable { get; set; } = lootable;
        public bool Removable { get; set; } = removable;
    }
}
