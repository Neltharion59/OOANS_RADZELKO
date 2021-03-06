﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SkillDamage : Skill
    {
        //public override string Effect { get; set; }
        //public override ITriggerBehaviour TriggerBehaviour { get; set; }
        public int DamageAmount { get; set; }

        public SkillDamage(String Name, int DamageAmount, ITriggerBehaviour TriggerBehaviour, int range, int maxTargets, int Treshold, bool pass)
        {
            this.Name = Name;
            this.DamageAmount = DamageAmount;
            this.TriggerBehaviour = TriggerBehaviour;
            this.Range = range;
            this.MaxTargets = maxTargets;
            this.TriggerTreshold = Treshold;
            this.Passive = pass;
        }

        public override void Use(List<Field> targets, double coeficient)
        {
            foreach (Field target in targets)
            {
                if (target.GetHero() != null)
                {
                    //Console.WriteLine("Dealing " + (int)(DamageAmount * coeficient) + " damage to " + target.Hero.GetHeroName());
                    Console.Write("Dealing damage to " + target.GetHero().GetHeroName());
                    //Console.WriteLine("\nCauseDamageSkill coeficient: " + coeficient + " damage amount: " + DamageAmount);
                    target.GetHero().DealDamage((int)(DamageAmount * coeficient));

                }
            }
        }

        protected override bool TargetSelf()
        {
            return false;
        }
    }
}
