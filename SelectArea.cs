using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SelectArea : ITriggerBehaviour
    {
        private static SelectArea Instance = null;
        private SelectArea() { }
        public static SelectArea GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SelectArea();
            }
            return Instance;
        }
        public double CalculateCoeficient(Field source, int MaxTargets)
        {
            return 0.5 * source.Hero.CalculateDamageModifier();
        }

        public List<Field> selectTargets(Battlefield battlefield, Field source, int SkillRange, int MaxTargets, bool targetSelf)
        {
            List<Field> targets = new List<Field>();

            for(int x = -SkillRange; x <= SkillRange; x++)
            {
                for(int y = -SkillRange; y <= SkillRange; y++)
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
                        catch( Exception e)
                        {

                        }
                    }
              
                }
            }

            return targets;
        }
    }
}
