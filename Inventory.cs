using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleTables;

namespace OOANS_projekt
{
    public class Inventory : Iterable
    {
        public List<AbstractItem> Items = new List<AbstractItem>();
        public int Money { get; set; }
        
        public Iterator CreateIterator(int type)
        {
            if(type == 0)
            {
                return new AllItemsIterator(this.Items);
            }
            else
            {
                return new SimpleIterator(this.Items);
            }   
        }
        
        public void AddItem(AbstractItem item)
        {
            this.Items.Add(item);
        }
        public void RemoveItem(int selection)
        {
            this.Items.RemoveAt(selection);
        }
}}