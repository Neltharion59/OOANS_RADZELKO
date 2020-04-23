using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class DamageResistanceBuff : Effect
    {
        public int DamageResistance { get; set; }
        
        public DamageResistanceBuff(String name, int duration, int damageResistance)
        {
            this.Name = name;
            this.Duration = duration;
            this.DamageResistance = damageResistance;
        }

        public override void Apply(HeroInterface hero)
        {
            ((HeroProxy)hero).damageResistance = this.DamageResistance;
        }
    }
}
