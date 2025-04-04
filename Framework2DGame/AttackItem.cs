using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;
using Framework2DGame.Interfaces;

namespace Framework2DGame
{
    public class AttackItem : WorldObject, IAttackItem
    {
        public int Hit { get; }
        public int Range {  get; }

        public AttackItem(string name, int hit, int range, bool lootable, bool removable, string description, World world)
        : base(name, lootable, removable, description, ItemCategory.attack, world)
        {
            Hit = hit;
            Range = range;
            
        }


    }
}
