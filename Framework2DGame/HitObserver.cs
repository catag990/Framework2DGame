using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame
{
    public class HitObserver : IObserver
    {
        public void OnCreatureHit(Creature creature, int damage)
        {
            Console.WriteLine($"Observer: {creature.Name} was hit for {damage}");
        }
    }
}
