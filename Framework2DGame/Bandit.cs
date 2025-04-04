using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame
{
    public class Bandit(ReadConfig config, string name, int hitPoint, int positionX, int positionY, World world) : Creature(config, name, hitPoint, positionX, positionY, world)
    {
        public int damage = 10;
        public void Throw(Creature creature)
        {
            Console.WriteLine($"{name} threw {creature.Name}, dealing {damage * 2} damage.");
            Hit(creature, damage * 2);

        }


        public bool CheckBoundaries(ReadConfig config, int positionX, int positionY)
        {
            if (positionX < config.maxX && positionY < config.maxY)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
    
}
