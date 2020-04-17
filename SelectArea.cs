using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SelectArea : SkillTriggering
    {
        protected override double CalculateCoeficient(Skill skill, Field source)
        {
            return 0.5 * source.Hero.CalculateDamageModifier();
        }

        protected override List<Field> selectTargets(Skill skill, Battlefield battlefield, Field source, bool targetSelf)
        {
            List<Field> targets = new List<Field>();

            for(int x = -skill.Range; x <= skill.Range; x++)
            {
                for(int y = -skill.Range; y <= skill.Range; y++)
                {
                    if (!(x == 0 && y == 0 && !targetSelf))
                    {
                        try
                        {
                            if (battlefield.GetField(source.x + x, source.y + y).Hero != null)
                            {
                                targets.Add(battlefield.GetField(source.x + x, source.y + y));
                            }
                        }
                        catch
                        {

                        }
                    }
              
                }
            }

            return targets;
        }
    }
}
