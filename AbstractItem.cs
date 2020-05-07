using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    public abstract class AbstractItem
    {
        public abstract bool Sell(Inventory Inventory);
        public abstract void Accept(ItemVisitor Visitor);
    }
}
