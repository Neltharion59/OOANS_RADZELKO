using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
public interface ItemVisitor
{
    void Visit(Item Item);
    void Visit(Backpack Backpack);
}}