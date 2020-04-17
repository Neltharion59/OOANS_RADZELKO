using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class DamageReduceDebuff : Effect
    {
        public int DamageReduce { get; set; }

        public DamageReduceDebuff(String name, int duration, int damageReduce)
        {
            this.Name = name;
            this.Duration = duration;
            this.DamageReduce = damageReduce;
        }

        public override void Apply(HeroInterface hero)
        {
            ((ProxyHero)hero).damageReduce = this.DamageReduce;
        }
    }
}
