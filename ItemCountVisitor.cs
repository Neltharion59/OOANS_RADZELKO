using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
public ItemCountVisitor : ItemVisitor
{
    int count = 0;
    void Visit(Item Item)
    {
        count++;
    }
    void Visit(Backpack Backpack)
    {
        for (AbstractItem item in Backpack.Insides.getItems())
        {
            this.Visit(item);
        }
        count++;
    }
}}