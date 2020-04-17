using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Hero : HeroInterface
    {
        public List<Skill> Skills { get; set; }
        public HealthStat HP { get; set; }
        public String name { get; set; }

        public Hero(List<Skill> Skills, int HealthPoints, String name)
        {
            this.Skills = Skills;
            this.HP = new HealthStat(HealthPoints, this);
            this.name = name;
        }

        public Skill GetSkill(int id) //TODO vymyslet to inak?  nie podla id
        {
            return this.Skills[id];
        }

        public HealthStat GetHealthStat()
        {
            return this.HP;
        }

        public String GetHeroName()
        {
            return this.name;
        }

        public void DealDamage(int amount)
        {
            this.HP.DealDamage(amount);
        }

        public void HealHealth(int amount)
        {
            this.HP.Heal(amount);
        }

        public void AddEffect(Effect effect)
        {
            
        }

        public void RemoveEffect(Effect effect)
        {
            
        }

        public double CalculateDamageModifier()
        {
            return 1.0;
        }

    }
}
