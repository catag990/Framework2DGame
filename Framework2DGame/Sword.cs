using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    public class Sword(string name, int hit, int range, bool lootable, bool removable, string description, World world) : 
        AttackItem(name, hit, range, lootable, removable, description, world)
    {

    }
}
