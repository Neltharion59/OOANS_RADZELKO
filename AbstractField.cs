using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class AbstractField
    {
        public abstract bool MoveHero(HeroInterface Hero, Field Previous);
    }
}
