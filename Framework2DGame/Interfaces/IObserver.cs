using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame.Interfaces
{
    public interface IObserver
    {
        void OnCreatureHit(Creature creature, int damage);
    }
}
