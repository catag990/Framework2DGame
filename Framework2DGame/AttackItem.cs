using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;
using Framework2DGame.Interfaces;

namespace Framework2DGame
{
    /// <summary>
    /// Item that can deal damage
    /// </summary>
    public class AttackItem : WorldObject, IAttackItem
    {
        public int Hit { get; }
        public int Range {  get; }

        public string Name { get; }
        /// <summary>
        /// Initializes an attack item
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <param name="hit">Damage of the item</param>
        /// <param name="range">Range of the item</param>
        /// <param name="lootable">If the item can be looted</param>
        /// <param name="removable">If the item can be removable</param>
        /// <param name="description">Description of the item</param>
        /// <param name="world">Reference to the world it exist in</param>
        public AttackItem(string name, int hit, int range, bool lootable, bool removable, string description, World world)
        : base(name, lootable, removable, description, ItemCategory.attack, world)
        {
            Hit = hit;
            Range = range;
            Name = name;
            
        }


    }
}
