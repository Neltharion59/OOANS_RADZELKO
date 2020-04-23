using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class SkillComposed : Skill
    {
        public Skill DecoratedSkill;

        public SkillComposed(Skill skill)
        {
            this.DecoratedSkill = skill;
        }

        public override void Use(List<Field> targets, double coeficient)
        {
            DecoratedSkill.Use(targets, coeficient);
        }
    }
}
