using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SkillDamageDebuff : SkillComposed
    {
        public Effect debuff;
        public SkillDamageDebuff(Skill DecoratedSkill, Effect debuff, String name) : base(DecoratedSkill)
        {
            this.debuff = debuff;
            this.Name = name;
            this.Range = DecoratedSkill.Range;
            this.MaxTargets = DecoratedSkill.MaxTargets;
        }

        public override void Use(List<Field> targets, double coeficient)
        {
            base.Use(targets, coeficient);
            ApplyDebuff(targets);
        }

        private void ApplyDebuff(List<Field> targets)
        {
            foreach (Field target in targets)
            {
                if (target.Hero != null) //aplikovanie debuffu
                {
                    Console.WriteLine("Applying " + this.debuff.Name + " " /*+ this.debuff.DamageVulnerability*/ + " to " + target.Hero.GetHeroName());
                    target.Hero.AddEffect(this.debuff);
                }
            }
        }

        public override bool TargetSelf()
        {
            return false;
        }
    }
}
