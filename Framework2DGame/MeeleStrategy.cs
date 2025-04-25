using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame
{
    /// <summary>
    /// A type of strategy
    /// </summary>
    public class MeeleStrategy : IStrategy
    {
        /// <summary>
        /// Makes an attack on a specific target
        /// </summary>
        /// <param name="attacker">Creature that is giving the hit</param>
        /// <param name="target">Creature that is receiving the hit</param>
        public void Attack(Creature attacker, Creature target)
        {
            Console.WriteLine($"{attacker.Name} punches {target.Name}");
            attacker.Hit(target);
        }
    }
}
