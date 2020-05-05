using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class PriceIterator : Iterator
    {
        private Items[];
        private int pos = -1;
        public PriceIterator(Items[] Items)
        {
            this.Items = Items;
            this.Items.Sort(delegate(Item x, Item y)
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
        
        public bool HasNext()
        {
            if (pos < Items.size())
            {
                return true;
            }
            return false;
        }
        public Item Next()
        {
            if(this.HasNext())
            {
                pos++;
                return Items[pos];
            }
            return null;
        }
        
    }
}
