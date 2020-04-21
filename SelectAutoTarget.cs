using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SelectAutoTarget : ITriggerBehaviour
    {
        private static SelectAutoTarget Instance = null;
        private SelectAutoTarget() { }
        public static SelectAutoTarget GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SelectAutoTarget();
            }
            return Instance;
        }
        public  double CalculateCoeficient(Field source, int MaxTargets)
        {
            return MaxTargets > 1 ? 0.5 * source.Hero.CalculateDamageModifier() : 1 * source.Hero.CalculateDamageModifier();
        }

        public List<Field> selectTargets(Battlefield battlefield, Field source, int SkillRange, int MaxTargets, bool targetSelf)
        {
            List<FieldDistance> potencionalTargets = new List<FieldDistance>();
            List<Field> targets = new List<Field>();

            for (int x = -SkillRange; x <= SkillRange; x++)
            {
                for (int y = -SkillRange; y <= SkillRange; y++)
                {
                    if (!(x == 0 && y == 0 && !targetSelf))
                    {
                        try
                        {
                            if (battlefield.GetField(source.x + x, source.y + y).Hero != null)
                            {
                                potencionalTargets.Add(new FieldDistance(battlefield.GetField(source.x + x, source.y + y), 
                                                                         CalculateRange(x,y,source.x,source.y)));
                            }
                        }
                        catch
                        {

                        }
                    }

                }
            }

            potencionalTargets.OrderBy(potencionalTargets => potencionalTargets.distanceFromSource).ToList();
            
            for(int i = 0; i < MaxTargets - 1; i++)
            {
                //Console.WriteLine(target.field.Hero.GetHeroName());
                try
                {
                    targets.Add(potencionalTargets[i].field);
                }
                catch
                {

                }
            }

            return targets;
        }

        private double CalculateRange(int x, int y, int tx, int ty)
        {
            return Math.Sqrt((Math.Pow(x - tx, 2) + Math.Pow(y - ty, 2)));
        }

    }

    internal class FieldDistance
    {
        public Field field { get; set; }
        public double distanceFromSource { get; set; }

        public FieldDistance(Field field, double distanceFromSource)
        {
            this.field = field;
            this.distanceFromSource = distanceFromSource;
        }
    }

}
