﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;

namespace Framework2DGame.Interfaces
{
    /// <summary>
    /// Interface of an observer
    /// </summary>
    public interface IObserver
    {
        void OnCreatureHit(Creature creature, int damage);
    }
}
