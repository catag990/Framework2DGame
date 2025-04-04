using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;

namespace Framework2DGame
{
    internal class DefenseItem(string name, int reduceHitPoint, bool lootable, bool removable, string description, World world) : WorldObject(name, lootable, removable, description, ItemCategory.defense, world)
    {
        public int ReduceHitPoint = reduceHitPoint;
        
        
    }
}
