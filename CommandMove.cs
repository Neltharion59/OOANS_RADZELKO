using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class CommandMove : Command
    {
        private List<(int, int)> PathCoordinates { get; }

        public CommandMove(List<(int, int)> PathCoordinates)
        {
            this.PathCoordinates = PathCoordinates;
        }
        public override bool Execute(Battlefield Battlefield)
        {
            bool Success = true;
            AbstractField TempCurrent;
            AbstractField TempNext = null;
            List<AbstractField> PathFields = new List<AbstractField>();

            // Build chain of responsibility
            for (int i = 0; i < PathCoordinates.Count - 1; i++)
            {
                TempCurrent = Battlefield.GetField(PathCoordinates[i].Item1, PathCoordinates[i].Item2);
                TempNext = Battlefield.GetField(PathCoordinates[i + 1].Item1, PathCoordinates[i + 1].Item2);
                if (TempCurrent == null || TempNext == null)
                {
                    Success = false;
                    break;
                }
                if (i == 0 && TempCurrent.GetHero() == null)
                {
                    Success = false;
                    break;
                }

                TempCurrent.SetNextInChain(TempNext);
                PathFields.Add(TempCurrent);
            }
            if (TempNext != null)
            {
                PathFields.Add(TempNext);
            } 

            if (!Success)
            {
                CleanUpPath(PathFields);
                return false;
            }

            if (PathFields.Count > 1)
            {
                HeroInterface Hero = PathFields.First().GetHero();
                PathFields.First().SetHero();
                Success = PathFields[1].MoveHero(Hero, PathFields.First());
            }

            CleanUpPath(PathFields);

            return Success;
        }
        private void CleanUpPath(List<AbstractField> PathFields)
        {
            foreach(AbstractField Field in PathFields)
            {
                Field.SetNextInChain(NullField.GetInstance());
            }
        }
    }
}
