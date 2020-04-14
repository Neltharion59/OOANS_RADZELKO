using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Battlefield
    {
        private Field[][] BattleGrid { get; }

        public Battlefield(Field[][] BattleGrid)
        {
            for (int i = 0; i < BattleGrid.Length; i++)
            {
                for (int j = 0; j < BattleGrid[i].Length; j++)
                {
                    BattleGrid[i][j].x = i;
                    BattleGrid[i][j].y = j;
                }
            }

            this.BattleGrid = BattleGrid;
        }
        public Field GetField(int x, int y)
        {
            Field Result = null;
            try
            {
                Result = this.BattleGrid[x][y];
            }
            catch (Exception e)
            {
            }
            return Result;
        }

        public List<object[]> ToRenderableFormat()
        {
            List<object[]> Result = new List<object[]>();
            for (int i = 0; i < BattleGrid.Length; i++)
            {
                Result.Add(new object[BattleGrid[i].Length]);
                for (int j = 0; j < BattleGrid[i].Length; j++)
                {
                    BattleGrid[i][j].x = i;
                    BattleGrid[i][j].y = j;

                    Result.Last()[j] = BattleGrid[i][j].Hero == null ? "E" : "H";
                }
            }
            return Result;
        }
    }
}
