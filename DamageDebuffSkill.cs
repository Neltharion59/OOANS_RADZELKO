using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class DamageDebuffSkill : ComposedSkill
    {
        public Effect debuff;
        public DamageDebuffSkill(Skill DecoratedSkill, Effect debuff, String name) : base(DecoratedSkill)
        {
            this.debuff = debuff;
            this.Name = name;
        }

        public override void Trigger(Battlefield battlefield, Field source)
        {
            //base.Trigger(battlefield, source);
            TriggerBehaviour.Trigger(this, battlefield, source, false);
        }

        public override void Use(Battlefield battlefield, List<Field> targets, double coeficient)
        {
            base.Use(battlefield, targets, coeficient);
            ApplyDebuff(battlefield, targets);

        }

        private void ApplyDebuff(Battlefield battlefield, List<Field> targets)
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

        public override void Update(ObserverSubject subject, HeroInterface parentHero)
        {
            base.Update(subject, parentHero);
        }
    }
}
