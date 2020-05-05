using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class AbstractItem
    {
        public abstract bool Sell(Inventory Inventory);
        void Accept(ItemVisitor Visitor);
    }
}
