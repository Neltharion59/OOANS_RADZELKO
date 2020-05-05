using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleTables;

namespace OOANS_projekt
{
    class Inventory : Iterable
    {
        private LinkedList<AbstractItem> Items { get; set; }
        private int Money { get; set; }
        
        public Iterator CreateIterator(int type)
        {
            if(type = 0)
            {
                return new PriceIterator(this.Items);
            }
            else
            {
                return new NameIterator(this.Items));
            }   
        }
}}