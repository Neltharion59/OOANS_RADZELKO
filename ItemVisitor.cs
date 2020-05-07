using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
public interface ItemVisitor
    {
    public void Visit(AbstractItem Item);
    public void Visit(Backpack Backpack);
}}