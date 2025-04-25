using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;
using Framework2DGame.Interfaces;

namespace Framework2DGame.Others
{
    /// <summary>
    /// Observer of hits 
    /// </summary>
    public class HitObserver : IObserver
    {
        /// <summary>
        /// Observes when a creature has been hit
        /// </summary>
        /// <param name="creature">Creature that received the hit</param>
        /// <param name="damage">Damage that the creature received</param>
        public void OnCreatureHit(Creature creature, int damage)
        {
            Console.WriteLine($"Observer: {creature.Name} was hit for {damage}");
        }
    }
}
