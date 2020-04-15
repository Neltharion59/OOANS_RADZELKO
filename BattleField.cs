using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Battlefield
    {
        private List<List<Field>> BattleGrid { get; }
        public List<HeroInterface> Heroes { get; }

        public Battlefield(List<List<Field>> BattleGrid)
        {
            for (int i = 0; i < BattleGrid.Count; i++)
            {
                for (int j = 0; j < BattleGrid[i].Count; j++)
                {
                    BattleGrid[i][j].x = i;
                    BattleGrid[i][j].y = j;
                }
            }

            this.BattleGrid = BattleGrid;

            this.Heroes = new List<HeroInterface>();
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

        public void AddHero(HeroInterface Hero, int x, int y)
        {
            Field Field = GetField(x, y);
            if (Field != null)
            {
                this.Heroes.Add(Hero);
                Field.SetHero(Hero);           
            }
        }

        public List<object[]> ToRenderableFormat()
        {
            List<object[]> Result = new List<object[]>();
            for (int i = 0; i < BattleGrid.Count; i++)
            {
                Result.Add(new object[BattleGrid[i].Count + 1]);
                Result.Last()[0] = i;
                for (int j = 0; j < BattleGrid[i].Count; j++)
                {
                    BattleGrid[i][j].x = i;
                    BattleGrid[i][j].y = j;

                    Result.Last()[j + 1] = BattleGrid[i][j].ToScreenText() + ", " + (BattleGrid[i][j].Hero == null ? "E" : "H");
                }
            }
            return Result;
        }

        public BattlefieldMemento CreateMemento()
        {
            BattlefieldMemento Memento = new BattlefieldMemento();
            foreach (List < Field > Row in this.BattleGrid)
            {
                Memento.BattleGrid.Add(Row.Select(x => x.CreateMemento()).ToList());
            }
            foreach (HeroInterface Hero in this.Heroes)
            {
                Memento.Heroes.Add(Hero.CreateMemento());
            }
            return Memento;
        }

        public void Restore(BattlefieldMemento Memento)
        {
            for (int i = 0; i < BattleGrid.Count; i++)
            {
                for (int j = 0; j < BattleGrid[i].Count; j++)
                {
                    BattleGrid[i][j].Restore(Memento.BattleGrid[i][j]);
                }
            }
            for (int i = 0; i < this.Heroes.Count; i++)
            {
                this.Heroes[i].Restore(Memento.Heroes[i]);
                Field Temp = GetField(this.Heroes[i].GetCoordinates()[0], this.Heroes[i].GetCoordinates()[1]);
                if (Temp != null && !this.Heroes[i].IsDead())
                {
                    Temp.SetHero(this.Heroes[i]);
                }
            }
        }

        public LinkedList<HeroInterface> GetAllHeroes()
        {
            LinkedList<HeroInterface> Result = new LinkedList<HeroInterface>();

            foreach (HeroInterface Hero in this.Heroes)
            {
                Result.AddLast(Hero);
            }

            return Result;
        }
    }
}
