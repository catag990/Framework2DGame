using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame.Base
{
    public class WorldObject : IObject
    {
        public string Name;
        public bool Lootable;
        public bool Removable;
        public string Description { get; }
        public ItemCategory Category { get; }


        public WorldObject(string name, bool lootable, bool removable, string description, ItemCategory category, World world)
        {
            Name = name;
            Lootable = lootable;
            Removable = removable;
            Description = description;
            Category = category;
            world.objects.Add(this);
        }

        public override string ToString()
        {
            return $"{Description} {GetType().Name}, removable: {Removable}, lootable: {Lootable}";
        }
    }
}
