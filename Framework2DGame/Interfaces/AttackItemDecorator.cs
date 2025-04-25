using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame.Interfaces
{

    /// <summary>
    /// Decorator for the interface of the attack item
    /// </summary>
    public class AttackItemDecorator : IAttackItem
    {
        private IAttackItem _attackItem;
        private int _boost;


        /// <summary>
        /// Initializes a instance of the AttackItemDecorator
        /// </summary>
        /// <param name="attackItem">The attack item to decorate</param>
        /// <param name="boost">Value to boost the damage of the item</param>
        public AttackItemDecorator(IAttackItem attackItem, int boost)
        {
            _attackItem = attackItem;
            _boost = boost;
        }
        public string Name => _attackItem.Name;
        public int Range => _attackItem.Range;

        public int Hit => _attackItem.Hit + _boost;

        public string Description => _attackItem.Description;

    }
}
