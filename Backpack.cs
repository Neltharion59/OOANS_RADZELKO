using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    public class Backpack : AbstractItem
    {
        public Inventory Insides;
        public override bool Sell(Inventory Inventory)
        {
            foreach (AbstractItem item in Inventory.Items)
            {
                item.Sell(Inventory);
            }
            Inventory.Money += Insides.Money + this.Price;
            return true;
        }
           
        public override void Accept(ItemVisitor Visitor)
        {
            Visitor.Visit(this);
        }

    }
}
