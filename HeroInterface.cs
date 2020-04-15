using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface HeroInterface
    {
        bool Move(int MoveCost);
        bool IsDead();
        HeroMemento CreateMemento();
        void Restore(HeroMemento Memento);
        void RestoreTurn();
        void SetCoordinates(int x, int y);
        int[] GetCoordinates();
    }
}
