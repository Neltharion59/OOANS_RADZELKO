using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class NameIterator : Iterator
    {
        private List<AbstractItem> Items;
        private int pos = -1;
        public NameIterator(List<AbstractItem> Items)
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
