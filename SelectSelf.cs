using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SelectSelf : SkillTriggering
    {
        protected override double CalculateCoeficient(Skill skill, Field source)
        {
            return 1.0 * source.Hero.CalculateDamageModifier();
        }

        protected override List<Field> selectTargets(Skill skill, Battlefield battlefield, Field source, bool targetSelf)
        {
            List<Field> targets = new List<Field>();
            targets.Add(source);

            return targets;
        }
    }
}
