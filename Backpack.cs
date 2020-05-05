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
        public Inventory Insides;
        public abstract bool Sell(Inventory Inventory)
        {
            for (AbstractItem item in Inventory.getItems())
            {
                item.Sell(Inventory);
            }
            Inventory.setMoney(Inventory.getMoney() + Insides.getMoney() + this.Price);   
        }
           
        void Accept(ItemVisitor Visitor)
        {
            Visitor.Visit(this);
        }

    }
}
