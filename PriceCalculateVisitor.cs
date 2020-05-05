using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
public PriceCalculateVisitor : ItemVisitor
{
    int value = 0;
    void Visit(Item Item)
    {
        value += Item.price;
    }
    void Visit(Backpack Backpack)
    {
        for (AbstractItem item in Backpack.Insides.getItems())
        {
            this.Visit(item);
        }
        value += Backpack.price;
    }
}}