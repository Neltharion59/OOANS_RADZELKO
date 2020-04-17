using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface HeroInterface
    {
        bool PayActionCost(int ActionCost);
        void BoostActionPoints(int Amount);
        bool IsDead();
        HeroMemento CreateMemento();
        void Restore(HeroMemento Memento);
        void RestoreTurn();
        void SetCoordinates(int x, int y);
        int[] GetCoordinates();
        int GetRemainingSteps();
        int GetHavervestPower();
        bool AddResource(Resource Resource);
    }
}
