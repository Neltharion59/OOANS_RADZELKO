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
                    Fields[i][j] = new Field();
                }
            }


            Battlefield Battlefield = new Battlefield(Fields.Select(x => x.ToList()).ToList());

            Fields[0][3].State = ImpassableFieldState.GetInstance();

            Fields[2][2].State = ImpassableFieldState.GetInstance();
            Fields[2][3].State = ImpassableFieldState.GetInstance();
            Fields[3][2].State = ImpassableFieldState.GetInstance();
            Fields[3][3].State = ImpassableFieldState.GetInstance();

            Fields[1][3].State = new TrappedFieldState();
            Fields[1][4].State = new TrappedFieldState();

            Hero Hero = new Hero();
            Hero.MovementPoints = 5;
            Hero.RemainingMovementPoints = 5;
            Battlefield.AddHero(Hero, 0, 0);
            Hero = new Hero();
            Hero.MovementPoints = 5;
            Hero.RemainingMovementPoints = 5;
            Battlefield.AddHero(Hero, 4, 4);
            BattleController bc = new BattleController(Battlefield);



            List<(int, int)> Coordinates = new List<(int, int)>();
            Coordinates.Add((0, 0));
            Coordinates.Add((0, 1));
            Coordinates.Add((0, 2));
            Coordinates.Add((0, 3));
            Coordinates.Add((1, 3));
            Coordinates.Add((2, 3));
            Coordinates.Add((2, 2));
            Command Command = new MoveCommand(Coordinates);

            //BattlefieldMemento Memento = Battlefield.CreateMemento();
            //Console.WriteLine(Memento.BattleGrid.Count);
            //Console.WriteLine(Memento.BattleGrid[0].Count);
            //Command.Execute(Battlefield);

            //Battlefield.Restore(Memento);

            /*table
                 .AddRow("this line should be longer", "yes it is", "oh");
            table.AddRow(Temp);
            table.Write();*/



            //Console.ReadLine();
        }
    }
}
