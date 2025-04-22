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

        public List<WorldObject> Inventory = new List<WorldObject>();

        //https://refactoring.guru/design-patterns/observer/csharp/example
        private List<IObserver> _observers = new List<IObserver>();

        public IStrategy Strategy {  get; set; }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        private void NotifyHit(int damage)
        {
            foreach (var observer in _observers)
            {
                observer.OnCreatureHit(this, damage);
            }
        }

        /// <summary>
        /// Defining the parameters of the class Creature
        /// </summary>
        /// <param name="name">Name of the creature</param>
        /// <param name="hitPoint">Health of the creature</param>
        /// <param name="positionX">Position of the creature in the x-axis</param>
        /// <param name="positionY">Position of the creature in the y-axis</param>
        /// <param name="ThisWorld">A reference to the World class, to add the creature in the list</param>
        public Creature(string name, int hitPoint, int positionX, int positionY, World ThisWorld)
        {
            Name = name;
            HitPoint = hitPoint;
            PositionX = positionX;
            PositionY = positionY;
            world = ThisWorld;
            

            world.creatures.Add(this);
        }

        /// <summary>
        /// Does the strategy that the creature has.
        /// </summary>
        /// <param name="creature">Creature that receives the attack</param>
        public void Attack(Creature creature)
        {
            if (Strategy == null)
            {
                Console.WriteLine($"{Name} has no strategy");
                return;
            }
            
            Strategy.Attack(this, creature);
        }


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
            NotifyHit(hit);
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

        //LINQ
        /// <summary>
        /// Searches for all the items of a given category in the inventory
        /// </summary>
        /// <param name="category">Item category that is being searched</param>
        /// <returns>List of items of the searched category</returns>
        public List<WorldObject> GetItemsByCategory(ItemCategory category)
        {
            return Inventory.Where(obj => obj.Category == category).ToList();
        }



    }
}
