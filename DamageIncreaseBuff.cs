using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class DamageIncreaseBuff : Effect
    {
        private int DamageIncrease { get; }

        public DamageIncreaseBuff(String name, int duration, int damageIncrease)
        {
            this.Name = name;
            this.Duration = duration;
            this.DamageIncrease = damageIncrease;
        }

        public override void Apply(HeroInterface hero)
        {
            ((HeroProxy)hero).damageIncrease = this.DamageIncrease;
        }
    }
}
