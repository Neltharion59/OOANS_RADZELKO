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

            Battlefield Battlefield = new Battlefield(Fields.Select(x => x.ToList()).ToList());

            Fields[0][1].SetStateNew(ForestFieldState.GetInstance());
            Fields[0][3].SetStateNew(ImpassableFieldState.GetInstance());

            Fields[2][2].SetStateNew(ImpassableFieldState.GetInstance());
            Fields[2][3].SetStateNew(ImpassableFieldState.GetInstance());
            Fields[3][2].SetStateNew(ImpassableFieldState.GetInstance());
            Fields[3][3].SetStateNew(ImpassableFieldState.GetInstance());

            Fields[1][3].SetStateNew(NormalFieldState.GetInstance());
            Fields[1][4].SetStateNew(NormalFieldState.GetInstance());

            Hero Hero = new Hero();
            Hero.ActionPoints = 5;
            Hero.RemainingActionPoints = 5;
            Battlefield.AddHero(Hero, 0, 0);
            Hero = new Hero();
            Hero.ActionPoints = 5;
            Hero.RemainingActionPoints = 5;
            Battlefield.AddHero(Hero, 4, 4);
            BattleController bc = new BattleController(Battlefield);
        }
    }
}
