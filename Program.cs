using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace OOANS_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Field[][] Fields = new Field[5][];
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = new Field[5];
                for (int j = 0; j < Fields[i].Length; j++)
                {
                    Fields[i][j] = new Field(i, j);
                }
            }

            Fields[0][1].SetStateNew(FieldStateForest.GetInstance());
            Fields[0][3].SetStateNew(FieldStateImpassable.GetInstance());

            Fields[2][2].SetStateNew(FieldStateImpassable.GetInstance());
            Fields[2][3].SetStateNew(FieldStateImpassable.GetInstance());
            Fields[3][2].SetStateNew(FieldStateImpassable.GetInstance());
            Fields[3][3].SetStateNew(FieldStateImpassable.GetInstance());

            Fields[1][3].SetStateNew(FieldStateNormal.GetInstance());
            Fields[1][4].SetStateNew(FieldStateNormal.GetInstance());

            Battlefield bf = new Battlefield(Fields.Select(x => x.ToList()).ToList());
            BattleController bc = new BattleController(bf);

            PrepareHeroes(bf);

            bc.ReceiveCommands();
            Console.ReadLine();
        }

        private static void PrepareHeroes(Battlefield Battlefield)
        {
            Hero Hero = new Hero(new List<Skill>(), 100, "Hero1");
            Hero.ActionPoints = 5;

            Hero.Skills.Add(
                new SkillDamage(
                    "Active damage",
                    40,
                    SelectOneTarget.GetInstance(),
                    3,
                    5,
                    90,
                    false
                )
            );
            Hero.Skills.Add(
                new SkillHeal(
                    "Passive self healing",
                    20,
                    SelectSelf.GetInstance(),
                    1,
                    1,
                    80,
                    true
                )
            );


            HeroProxy Herop = new HeroProxy(Hero);
            Battlefield.AddHero(Herop, 0, 0);

            Hero = new Hero(new List<Skill>(), 50, "Hero3");
            Hero.ActionPoints = 4;

            Hero.Skills.Add(
                new SkillDamage(
                    "Active damage",
                    40,
                    SelectOneTarget.GetInstance(),
                    3,
                    5,
                    90,
                    false
                )
            );
            Hero.Skills.Add(
                new SkillPlaceTrap(
                    new SkillDamage("Trap Damage", 20, SelectSelf.GetInstance(), 1, 1, 50, false),
                    "Trapp-Placing skill",
                    SelectOneTarget.GetInstance(),
                    1,
                    1,
                    20,
                    false
                )
            );

            Herop = new HeroProxy(Hero);
            Battlefield.AddHero(Herop, 4, 4);
        }
    }
}
