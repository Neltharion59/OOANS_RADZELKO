using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Backpack : AbstractItem
    {
        public string Name;
        public int Price;
        public Inventory Insides;
        public override bool Sell(Inventory Inventory)
        {
            foreach (AbstractItem item in Inventory.getItems())
            {
                item.Sell(Inventory);
            }
            Inventory.setMoney(Inventory.getMoney() + Insides.getMoney() + this.Price);
            return true;
        }
           
        void Accept(ItemVisitor Visitor)
        {
            Visitor.Visit(this);
        }

    }
}
