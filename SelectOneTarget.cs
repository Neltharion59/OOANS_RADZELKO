using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SelectOneTarget : ITriggerBehaviour
    {
        private static SelectOneTarget Instance = null;
        private SelectOneTarget() { }
        public static SelectOneTarget GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SelectOneTarget();
            }
            return Instance;
        }
        public double CalculateCoeficient(Field source, int MaxTargets)
        {
            //Console.WriteLine("Calculate coeficient: " + source.Hero.CalculateDamageModifier());
            if (source.Hero != null)
            {
                return 1.0 * source.Hero.CalculateDamageModifier();
            }
            return 1.0;
        }

        public List<Field> selectTargets(Battlefield battlefield, Field source, int SkillRange, int MaxTargets, bool targetSelf)
        {
            List<Field> targets = new List<Field>();

            Console.WriteLine("You are standing in " + source.x + "," + source.y);

            while (true)
            {
                try {
                    Console.WriteLine("Select target coordinates (x,y):");
                    string coordinates = Console.ReadLine();
                    string[] c = coordinates.Split(',');
                    int x = Convert.ToInt32(c[0]);
                    int y = Convert.ToInt32(c[1]);

                    if (x > -1 && y > -1 && CalculateRange(x, y, source.x, source.y, SkillRange) == true) //ak nie som mimo mapy a range skillu sedi
                    {
                       /* if (battlefield.GetField(x, y).Hero == null)
                        {
                            Console.WriteLine("No hero on selected coordinates!");
                        }
                        else
                        {*/
                            Console.WriteLine("Adding selected coordinates " + x + "," + y + " to targets list!");
                            targets.Add(battlefield.GetField(x, y));
                            break;
                        //}
                    }
                    else
                    {
                        Console.WriteLine("Insuficient skill range!");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect input!");
                }
            }

            return targets;
        }

        private bool CalculateRange(int x, int y, int tx, int ty, int SkillRange)
        {
            //Console.WriteLine(Math.Floor(Math.Sqrt((Math.Pow(x - tx, 2) + Math.Pow(y - ty, 2)))));
            return Math.Floor(Math.Sqrt((Math.Pow(x - tx, 2) + Math.Pow(y - ty, 2)))) <= SkillRange;
        }

    }
}
