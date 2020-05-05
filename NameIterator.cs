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
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
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
