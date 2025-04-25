using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework2DGame.Interfaces;

namespace Framework2DGame.Items
{

    /// <summary>
    /// Composite class for grouping multiple attack items as one
    /// </summary>
    public class CompositeAttackItem : IAttackItem
    {
        protected List<IAttackItem> attackItems = new List<IAttackItem>();

        public string Description => NewDescription();
        public int Hit => TotalHit();
        public int Range => NewRange();


        /// <summary>
        /// Gets the combined name of all attack items in the composite
        /// </summary>
        public string Name
        {
            get
            {
                return string.Join(", ", attackItems.Select(item => item.Name));
            }
        }

        /// <summary>
        /// Adds an attack item to the composite
        /// </summary>
        /// <param name="attackItem">Attack item to add to the composite</param>
        public void Add(IAttackItem attackItem)
        {
            attackItems.Add(attackItem);
        }


        /// <summary>
        /// Removes an attack item from the composite
        /// </summary>
        /// <param name="attackItem">Attack item to be removed from the composite</param>
        public void Remove(IAttackItem attackItem)
        {
            attackItems.Remove(attackItem);
        }

        /// <summary>
        /// Gets the total damage from all items in the list of attack items
        /// </summary>
        /// <returns>Sum of damage of all the items</returns>
        public int TotalHit()
        {
            return attackItems.Sum(item => item.Hit);
        }

        /// <summary>
        /// Gest the lowest range of all attack items
        /// </summary>
        /// <returns>Minimum range of all attack items</returns>
        public int NewRange()
        {
            return attackItems.Min(item => item.Range);
        }

        /// <summary>
        /// Combines all the descriptions of the items
        /// </summary>
        /// <returns>Combined description</returns>
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
