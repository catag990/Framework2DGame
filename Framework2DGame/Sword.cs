using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;
using Framework2DGame.Items;

namespace Framework2DGame
{
    /// <summary>
    /// Type of Attack Item, sword type
    /// </summary>
    /// <param name="name">Name of the item</param>
    /// <param name="hit">Damage that the item deals</param>
    /// <param name="range">Range of the item</param>
    /// <param name="lootable">If the item is lootable</param>
    /// <param name="removable">If the item is removable</param>
    /// <param name="description">Description of the item</param>
    /// <param name="world">Reference to the world it exist in</param>
    public class Sword(string name, int hit, int range, bool lootable, bool removable, string description, World world) :
        AttackItem(name, hit, range, lootable, removable, description, world)
    {

    }
}
