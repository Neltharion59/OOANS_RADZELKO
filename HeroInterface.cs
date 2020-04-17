using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface HeroInterface
    {
        public Skill GetSkill(int id);
        public HealthStat GetHealthStat();
        public String GetHeroName();
        public void DealDamage(int amount);
        public void HealHealth(int amount);
        public void AddEffect(Effect effect);
        public void RemoveEffect(Effect effect);
        public double CalculateDamageModifier();
    }
}
