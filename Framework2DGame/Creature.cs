using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;

namespace Framework2DGame
{
    /// <summary>
    /// Creature is an abstract class that provides a generic template for making different creatures.
    /// </summary>
    public abstract class Creature
    {
        public string Name { get; }
        public int HitPoint { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        

        public World world;
        public bool Dead { get { return HitPoint <= 0; } }

        /// <summary>
        /// Defining the parameters of the class Creature
        /// </summary>
        /// <param name="config">Filename of the configuration file</param>
        /// <param name="name">Name of the creature</param>
        /// <param name="hitPoint">Health of the creature</param>
        /// <param name="positionX">Position of the creature in the x-axis</param>
        /// <param name="positionY">Position of the creature in the y-axis</param>
        /// <param name="ThisWorld">A reference to the World class, to add the creature in the list</param>
        public Creature(ReadConfig config, string name, int hitPoint, int positionX, int positionY, World ThisWorld)
        {
            Name = name;
            HitPoint = hitPoint;
            PositionX = positionX;
            PositionY = positionY;
            world = ThisWorld;
            

            world.creatures.Add(this);



        }

        
        
        public List<WorldObject> Inventory = new List<WorldObject>();

        /// <summary>
        /// Deals damage to other entity
        /// </summary>
        /// <returns>Damage made to other entity</returns>
        public void Hit(Creature creature, int damage)
        {
            creature.ReceiveHit(damage);
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
                Console.WriteLine($"{Name} died.");
                world.creatures.Remove(this);
            }
        }

        /// <summary>
        /// Tries looting an object, can pick it up if it's lootable
        /// </summary>
        /// <param name="obj">Object that is being looted</param>
        public void Loot(WorldObject obj)
        {
            if (obj.Lootable) {
                Console.WriteLine($"The object {obj.Name} has been looted by {Name}.");
                world.objects.Remove(obj);
                Inventory.Add(obj);
            }
            else
            {
                Console.WriteLine($"The object {obj.Name} can't be looted.");
            }
        }
        

    }
}
