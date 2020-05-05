using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Item : AbstractItem
    {
        public string Name;
        public int Price;
        public abstract bool Sell(Inventory Inventory)
        {
            Inventory.setMoney(Inventory.getMoney() + this.Price);
        }
        
        
    }
}
