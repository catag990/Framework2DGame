using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework2DGame.Interfaces
{
    public class AttackItemDecorator : IAttackItem
    {
        private IAttackItem _attackItem;
        private int _boost;
        public AttackItemDecorator(IAttackItem attackItem, int boost)
        {
            _attackItem = attackItem;
            _boost = boost;
        }
        public int Range => _attackItem.Range;

        public int Hit => _attackItem.Hit + _boost;

        public string Description => _attackItem.Description;

    }
}
