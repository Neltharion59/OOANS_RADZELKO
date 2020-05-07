using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    public abstract class Iterator
    {
        public abstract bool HasNext();
        public abstract AbstractItem Next();
        
    }
}
