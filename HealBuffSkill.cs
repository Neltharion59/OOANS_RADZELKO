using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HealBuffSkill : ComposedSkill
    {
        public Effect buff;
        public HealBuffSkill(Skill DecoratedSkill, Effect buff, String name) : base(DecoratedSkill)
        {
            this.buff = buff;
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
            ApplyBuff(battlefield, targets);

        }

        private void ApplyBuff(Battlefield battlefield, List<Field> targets)
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

        public override void Update(ObserverSubject subject, HeroInterface parentHero)
        {
            base.Update(subject, parentHero);
        }

    }
}
