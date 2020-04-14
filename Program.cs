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
            Battlefield Battlefield = new Battlefield(Fields);

            Fields[0][0].Hero = new Hero();

            List<(int, int)> Coordinates = new List<(int, int)>();
            Coordinates.Add((0, 0));
            Coordinates.Add((0, 1));
            Coordinates.Add((0, 2));
            Coordinates.Add((0, 3));
            Coordinates.Add((1, 3));
            Coordinates.Add((2, 3));
            Coordinates.Add((2, 2));
            Command Command = new MoveCommand(Coordinates);

            Command.Execute(Battlefield);

            object[] Temp = { "ahj", "asda", "asda"};

            
            /*table
                 .AddRow("this line should be longer", "yes it is", "oh");
            table.AddRow(Temp);
            table.Write();*/

            List<object[]> a = Battlefield.ToRenderableFormat();

            String[] Placeholder = new string[a[0].Length];
            for (int i = 0; i < Placeholder.Length; i++)
            {
                Placeholder[i] = i.ToString();
            }
            var table = new ConsoleTable(Placeholder);
            foreach (object[] O in a)
            {
                table.AddRow(O);
            }
            table.Write();

            Console.ReadLine();
        }
    }
}
