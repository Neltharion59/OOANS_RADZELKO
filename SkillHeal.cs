using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SkillHeal : Skill
    {
        public int HealAmount { get; set; }


        public SkillHeal(String Effect, int HealAmount, ITriggerBehaviour triggerBehaviour, int range, int maxTargets, int tTreshold, bool pass)
        {
            this.Name = Effect;
            this.HealAmount = HealAmount;
            this.Range = range;
            this.TriggerBehaviour = triggerBehaviour;
            this.MaxTargets = maxTargets;
            this.TriggerTreshold = tTreshold;
            this.Passive = pass;
        }

        public override void Use(List<Field> targets, double coeficient)
        {
            foreach (Field target in targets)
            {
                if (target.GetHero() != null)
                {
                    Console.WriteLine("Healing " + (int)(HealAmount * coeficient) + " health to " + target.GetHero().GetHeroName());
                    target.GetHero().HealHealth((int)(HealAmount * coeficient));
                }
            }
        }

        protected override bool TargetSelf()
        {
            return true;
        }
    }
}
