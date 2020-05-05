using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class PriceIterator : Iterator
    {
        private List<AbstractItem> Items;
        private int pos = -1;
        public PriceIterator(List<AbstractItem> Items)
        {
            this.Items = Items;
            this.Items.Sort(delegate (Item x, Item y)
            {
                if(x.price > y.price)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }            
        }
        
        public override bool HasNext()
        {
            if (pos < Items.Count())
            {
                return true;
            }
            return false;
        }
        public override AbstractItem Next()
        {
            if(this.HasNext())
            {
                pos++;
                return Items.ElementAt(pos);
            }
            return null;
        }
        
    }
}
