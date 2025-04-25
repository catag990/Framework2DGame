using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;

namespace Framework2DGame.Items
{

    /// <summary>
    /// Creates a Defense Item that 
    /// </summary>
    /// <param name="name">Name of the item</param>
    /// <param name="reduceDamage">Damage recieved reduced</param>
    /// <param name="lootable">If the item can be looted</param>
    /// <param name="removable">If the item can be removable</param>
    /// <param name="description">Description of the item</param>
    /// <param name="world">Reference to the world it exist in</param>
    public class DefenseItem(string name, int reduceDamage, bool lootable, bool removable, string description, World world)
        : WorldObject(name, lootable, removable, description, ItemCategory.defense, world)
    {
        public int ReducereduceDamage = reduceDamage;


    }
}
