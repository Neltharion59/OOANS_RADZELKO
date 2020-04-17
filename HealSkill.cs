using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HealSkill : Skill
    {
        public int HealAmount { get; set; }


        public HealSkill(String Effect, int HealAmount, ITriggerBehaviour triggerBehaviour, int range, int maxTargets, int tTreshold, bool pass)
        {
            this.Name = Effect;
            this.HealAmount = HealAmount;
            this.Range = range;
            this.TriggerBehaviour = triggerBehaviour;
            this.MaxTargets = maxTargets;
            this.TriggerTreshold = tTreshold;
            this.Passive = pass;
        }

        public override void Trigger(Battlefield battlefield, Field source)
        {
            TriggerBehaviour.Trigger(this, battlefield, source, true);
        }

        public override void Use(Battlefield battlefield, List<Field> targets, double coeficient)
        {
            foreach (Field target in targets)
            {
                if (target.Hero != null)
                {
                    Console.WriteLine("Healing " + (int)(HealAmount * coeficient) + " health to " + target.Hero.GetHeroName());
                    target.Hero.HealHealth((int)(HealAmount * coeficient));
                }
            }
        }

        public override void Update(ObserverSubject subject, HeroInterface parentHero)
        {
            if (this.Passive)
            {
                int MaxHP = ((HealthStat)subject).MaximumHP;
                int ActualHP = ((HealthStat)subject).ActualHP;

                if (ActualHP < this.TriggerTreshold)
                {
                    Console.WriteLine("akoze passive heal skill triggered, TODO, observer funguje");
                    //this.Trigger(battlefield: battlefield, Field: source);  //todo dostat sa cez hrdinu k fieldu

                }
            }
        }

    }
}
