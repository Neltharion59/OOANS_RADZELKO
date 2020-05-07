using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{

public class ItemCountVisitor : ItemVisitor
{
    public int count = 0;
    public void Visit(AbstractItem Item)
    {
        count++;
    }
    public void Visit(Backpack Backpack)
    {
        foreach (AbstractItem item in Backpack.Insides.Items)
        {
            this.Visit(item);
        }
        count++;
    }
}}