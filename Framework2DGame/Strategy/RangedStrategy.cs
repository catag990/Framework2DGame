﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Base;
using Framework2DGame.Interfaces;

namespace Framework2DGame.Strategy
{

    /// <summary>
    /// Type of strategy
    /// </summary>
    public class RangedStrategy : IStrategy
    {
        /// <summary>
        /// Makes an attack on a specific target, dealing half damage because of ranged hit
        /// </summary>
        /// <param name="attacker">Creature that is giving the hit</param>
        /// <param name="target">Creature that is receiving the hit</param>
        public void Attack(Creature attacker, Creature target)
        {
            Console.WriteLine($"{attacker.Name} shoots {target.Name}");
            attacker.Damage = attacker.Damage / 2;
            attacker.Hit(target);
            attacker.Damage = attacker.Damage * 2;
        }
    }
}
