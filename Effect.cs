using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class Effect
    {
        public String Name { get; set; }
        public int Duration { get; set; }

        public abstract void Apply(HeroInterface hero);
    }
}
