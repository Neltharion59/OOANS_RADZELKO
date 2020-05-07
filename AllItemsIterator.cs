using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class AllItemsIterator : Iterator
    {
        private List<AbstractItem> Items;
        private int pos = -1;

        private List<AbstractItem> ExtractContents(List<AbstractItem> Items)
        {
            List<AbstractItem> AllItems = new List<AbstractItem>();
            foreach(AbstractItem Item in Items)
            {
                AllItems.Add(Item);
                if(Item is Backpack)
                {
                    AllItems.AddRange(ExtractContents(((Backpack)Item).Insides.Items));
                }
            }
            return AllItems;
        }
        public AllItemsIterator(List<AbstractItem> Items)
        {
            this.Items = ExtractContents(Items);

        }
        
        public override bool HasNext()
        {
            if (pos + 1 < Items.Count())
            {
                return true;
            }
            if (Items.ElementAt(pos) is Backpack)
            {
                Backpack backpack = (Backpack)(Items.ElementAt(pos));
                if (backpack.Insides.Items.Count > 0)
                {
                    return true;
                }
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
