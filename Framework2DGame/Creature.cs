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
        public int Damage = 10;
        public int HitPoint { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        
        public World world;
        public bool Dead { get { return HitPoint <= 0; } }

        public List<WorldObject> Inventory = new List<WorldObject>();

        private IAttackItem _equippedWeapon;

        public IAttackItem EquippedWeapon
        {
            get { return _equippedWeapon; }
            set
            {
                _equippedWeapon = value;
            }
        }

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
            LoggingClass.Information($"Added creature {this.Name} to the world");
        }

        /// <summary>
        /// Does the strategy that the creature has.
        /// </summary>
        /// <param name="creature">Creature that receives the attack</param>
        public void Attack(Creature creature)
        {
            if (Dead) return;
            if (Strategy == null)
            {
                Console.WriteLine($"{Name} has no strategy");
                LoggingClass.Information($"No strategy for creature named {this.Name}");
                return;
            }
            
            Strategy.Attack(this, creature);
        }


        /// <summary>
        /// Deals damage to another creature
        /// </summary>
        /// <param name="creature">Creature that is receiving the hit</param>
        public void Hit(Creature creature)
        {
            if (!Dead)
            {
                if (EquippedWeapon != null)
                {
                    Damage = EquippedWeapon.Hit;
                }

                creature.ReceiveHit(Damage);
            }
        }

        /// <summary>
        /// Creature takes damage and reduces the life of it depending on the hit made
        /// </summary>
        /// <param name="hit">Damage received</param>
        public void ReceiveHit(int hit)
        {
            if (Dead) return;
            NotifyHit(hit);
            HitPoint -= hit;
            if (HitPoint <= 0)
            {
                Console.WriteLine($"{Name} died.");
                LoggingClass.Information($"{this.Name} removed from the world");
                world.creatures.Remove(this);
                
            }
        }

        /// <summary>
        /// Tries looting an object, can pick it up if it's lootable
        /// </summary>
        /// <param name="obj">Object that is being looted</param>
        public void Loot(WorldObject obj)
        {
            if (Dead) return;
            if (obj.Lootable && world.objects.Contains(obj)) {
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

        /// <summary>
        /// Equips a weapon by its name if it exists in the inventory and is an attack item
        /// </summary>
        /// <param name="weaponName">name of the weapon to equip</param>
        /// <returns>Bool if the weapon searched it's in the inventory or not</returns>
        public void EquipWeapon(string weaponName)
        {
            if (Dead) return;
            ///LINQ?
            var weapon = Inventory.FirstOrDefault(obj => obj is IAttackItem && obj.Name == weaponName) as IAttackItem;

            if (weapon != null)
            {
                EquippedWeapon = weapon;
                Console.WriteLine($"{Name} now has {weaponName} equipped.");
            }
            else
            {
                Console.WriteLine($"Weapon {weaponName} not found.");
            }
        }

        /// <summary>
        /// Method to apply a boost to the equipped weapon
        /// </summary>
        /// <param name="boost">The boost value to apply to the damage of the weapon</param>
        public void ApplyWeaponBoost(int boost)
        {
            if (Dead) return;
            if (_equippedWeapon != null)
            {
                EquippedWeapon = new AttackItemDecorator(_equippedWeapon, boost);
                Console.WriteLine($"The equipped weapon has been boosted by {boost}. New damage: {EquippedWeapon.Hit}");
            }
            else
            {
                Console.WriteLine("No weapon is equipped to boost");
            }
        }
    }
}
