using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    public class Creature(string name, int hitPoint)
    {
        public string Name { get; set; } = name;
        public int HitPoint { get; set; } = hitPoint;

        /// <summary>
        /// Deals damage to other entity
        /// </summary>
        /// <returns>Damage made to other entity</returns>
        public int Hit()
        {
            return 10;
        }

        /// <summary>
        /// Creature takes damage and reduces the life of it depending on the hit made
        /// </summary>
        /// <param name="hit">Damage received</param>
        public void ReceiveHit(int hit)
        {
            HitPoint -= hit;
            if (HitPoint <= 0)
            {
                Console.WriteLine($"{Name} died");
            }
        }

        /// <summary>
        /// Tries looting an object, can pick it up if it's lootable
        /// </summary>
        /// <param name="obj">Object that is being looted</param>
        public void Loot(WorldObject obj)
        {
            if (obj.Lootable) {
                Console.WriteLine($"Se ha looteado el objeto {obj.Name}");
            }
            else
            {
                Console.WriteLine($"No se puede saquear el objeto {obj.Name}");
            }
        }
    }
}
