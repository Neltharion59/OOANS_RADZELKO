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

        public override void Use(List<Field> targets, double coeficient)
        {
            DecoratedSkill.Use(targets, coeficient);
        }
    }
}
