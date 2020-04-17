﻿using System;
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

        public override void Use(List<Field> targets, double coeficient)
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

        public override bool TargetSelf()
        {
            return true;
        }
    }
}