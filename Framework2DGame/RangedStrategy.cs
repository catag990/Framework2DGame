using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame
{
    public class RangedStrategy : IStrategy
    {
        public void Attack(Creature attacker, Creature target)
        {
            Console.WriteLine($"{attacker.Name} shoots {target.Name}");
            attacker.Hit(target, 5);
        }
    }
}
