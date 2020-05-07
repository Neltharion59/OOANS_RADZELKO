using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SimpleIterator : Iterator
    {
        private List<AbstractItem> Items;
        private int pos = -1;
        public SimpleIterator(List<AbstractItem> Items)
        {
            this.Items = Items;         
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
