using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;

namespace Framework2DGame.Interfaces
{
    public interface IAttackItem : IObject
    {
        int Hit { get; }
        int Range { get; }

    }
}
