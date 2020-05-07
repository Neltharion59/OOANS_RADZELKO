using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
public class PriceCalculateVisitor : ItemVisitor
{
    public int value = 0;
    public void Visit(AbstractItem Item)
    {
        value += Item.Price;
    }
    public void Visit(Backpack Backpack)
    {
        foreach (AbstractItem item in Backpack.Insides.Items)
        {
            this.Visit(item);
        }
        value += Backpack.Price;
    }
}}