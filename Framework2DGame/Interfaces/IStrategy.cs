using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame.Interfaces
{
    public interface IStrategy
    {
        void Attack(Creature attacker, Creature target);
    }
}
