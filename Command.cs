using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class Command
    {
        public abstract bool Execute(Battlefield Battlefield);
    }
}
