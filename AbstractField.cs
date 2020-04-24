using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class AbstractField
    {
        public abstract bool MoveHero(HeroInterface Hero, AbstractField Previous);
        public abstract void SetHero(HeroInterface Hero = null);
        public abstract HeroInterface GetHero();
        public abstract void SetNextInChain(AbstractField Next);
    }
}
