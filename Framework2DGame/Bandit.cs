using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    /// <summary>
    /// A type of creature
    /// </summary>
    /// <param name="config">Config file</param>
    /// <param name="name">Name of the creature</param>
    /// <param name="hitPoint">Amount of life points the creature has</param>
    /// <param name="positionX">position of the creature in the X-axis</param>
    /// <param name="positionY">position of the creature in the Y-axis</param>
    /// <param name="world">World the creature is in</param>
    public class Bandit(ReadConfig config, string name, int hitPoint, int positionX, int positionY, World world) : Creature(name, hitPoint, positionX, positionY, world)
    {
        /// <summary>
        /// Type of hit that deals 2 times the normal damage
        /// </summary>
        /// <param name="creature">Creature receiving the hit</param>
        public void Throw(Creature creature)
        {
            Damage = Damage * 2;
            Console.WriteLine($"{name} threw {creature.Name}, dealing {Damage} damage.");
            Hit(creature);
            Damage = Damage / 2;

        }
    }
}
