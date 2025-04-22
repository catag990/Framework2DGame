using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame
{
    public class CompositeAttackItem : IAttackItem
    {
        protected List<IAttackItem> attackItems = new List<IAttackItem>();

        public string Description => NewDescription();
        public int Hit => TotalHit();
        public int Range => NewRange();

        public void Add(IAttackItem attackItem)
        {
            this.attackItems.Add(attackItem);
        }
        public void Remove(IAttackItem attackItem)
        {
            this.attackItems.Remove(attackItem);
        }

        public int TotalHit() =>
            attackItems.Sum(item => item.Hit);
        
        public int NewRange() =>
            attackItems.Min(item => item.Range);

        public string NewDescription()
        {
            StringBuilder sb = new();
            foreach (var item in attackItems) 
            { 
                sb.Append(item.Description); 
            } 
            return sb.ToString();
        }
            

    }
}
