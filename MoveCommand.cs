using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class MoveCommand : Command
    {
        private List<(int, int)> PathCoordinates { get; }

        public MoveCommand(List<(int, int)> PathCoordinates)
        {
            this.PathCoordinates = PathCoordinates;
        }
        public override bool Execute(Battlefield Battlefield)
        {
            bool Success = true;
            Field TempCurrent;
            Field TempNext;
            List<Field> PathFields = new List<Field>();

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
                if (i == 0 && TempCurrent.Hero == null)
                {
                    Success = false;
                    break;
                }

                TempCurrent.NextInChain = TempNext;
                PathFields.Add(TempCurrent);
            }

            if (!Success)
            {
                CleanUpPath(PathFields);
                return false;
            }

            Success = PathFields.First().MoveHero(PathFields.First().Hero);

            CleanUpPath(PathFields);

            return Success;
        }
        private void CleanUpPath(List<Field> PathFields)
        {
            foreach(Field Field in PathFields)
            {
                Field.NextInChain = NullField.GetInstance();
            }
        }
    }
}
