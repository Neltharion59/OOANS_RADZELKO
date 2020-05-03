using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SkillHealBuff : SkillComposed
    {
        public Effect buff;
        public SkillHealBuff(Skill DecoratedSkill, Effect buff, String name) : base(DecoratedSkill)
        {
            this.buff = buff;
            this.Name = name;
            this.Range = DecoratedSkill.Range;
            this.MaxTargets = DecoratedSkill.MaxTargets;
        }

        public override void Use(List<Field> targets, double coeficient)
        {
            base.Use(targets, coeficient);
            ApplyBuff(targets);
        }

        private void ApplyBuff(List<Field> targets)
        {
            foreach (Field target in targets)
            {
                if (target.Hero != null) //aplikovanie buffu
                {
                    Console.WriteLine("Applying " + this.buff.Name + " " + /*this.buff.DamageResistance +*/ " to " + target.Hero.GetHeroName());
                    target.Hero.AddEffect(this.buff);
                }
            }
        }

        public override bool TargetSelf()
        {
            return true;
        }
    }
}
