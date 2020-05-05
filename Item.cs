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
        public override bool Sell(Inventory Inventory)
        {
            Inventory.setMoney(Inventory.getMoney() + this.Price);
            return true;
        }
        
        void Accept(ItemVisitor Visitor)
        {
            Visitor.Visit(this);
        }
        
    }
}
