using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame
{
    public class MeeleStrategy : IStrategy
    {
        public void Attack(Creature attacker, Creature target)
        {
            Console.WriteLine($"{attacker.Name} punchs {target.Name}");
            attacker.Hit(target, 10);
        }
    }
}
