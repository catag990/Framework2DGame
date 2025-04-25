using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame.Base
{
    /// <summary>
    /// Item that is in a world
    /// </summary>
    public class WorldObject : IObject
    {
        public string Name;
        public bool Lootable;
        public bool Removable;
        public string Description { get; }
        public ItemCategory Category { get; }


        /// <summary>
        /// Initializes a world object
        /// </summary>
        /// <param name="name">Name of the object</param>
        /// <param name="lootable">If the item is lootable</param>
        /// <param name="removable">If the item is removable</param>
        /// <param name="description">Description of the item</param>
        /// <param name="category">Category of the item</param>
        /// <param name="world">Reference to the world it exist in</param>
        public WorldObject(string name, bool lootable, bool removable, string description, ItemCategory category, World world)
        {
            Name = name;
            Lootable = lootable;
            Removable = removable;
            Description = description;
            Category = category;
            world.objects.Add(this);
        }

    }
}
