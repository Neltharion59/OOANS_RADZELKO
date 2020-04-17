using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class ComposedSkill : Skill
    {
        public Skill DecoratedSkill;

        public ComposedSkill(Skill skill)
        {
            this.DecoratedSkill = skill;
        }

        public override void Trigger(Battlefield battlefield, Field source)
        {
            DecoratedSkill.Trigger(battlefield, source);
        }

        public override void Use(Battlefield battlefield, List<Field> targets, double coeficient)
        {
            DecoratedSkill.Use(battlefield, targets, coeficient);
        }

        public override void Update(ObserverSubject subject, HeroInterface parentHero)
        {
            DecoratedSkill.Update(subject, parentHero);
        }

    }
}
