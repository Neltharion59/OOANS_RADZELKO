using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Item : AbstractItem
    {
        public Item(int price, string name)
        {
            this.Price = price;
            this.Name = name;
        }
        public override bool Sell(Inventory Inventory)
        {
            Inventory.Money += this.Price;
            return true;
        }
        
        public override void Accept(ItemVisitor Visitor)
        {
            Visitor.Visit(this);
        }
        
    }
}
