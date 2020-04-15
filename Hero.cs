using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Hero : HeroInterface
    {
        public int MovementPoints { get; set; }
        public int RemainingMovementPoints { get; set; }
        public int x;
        public int y;

        public Hero()
        {
            this.MovementPoints = 0;
            this.RemainingMovementPoints = 0;

            this.x = -1;
            this.y = -1;
        }
        public bool IsDead()
        {
            return false;
        }

        public bool Move(int MoveCost)
        {
            if (MoveCost > RemainingMovementPoints)
            {
                return false;
            }
            RemainingMovementPoints -= MoveCost;
            return true;
        }
        public HeroMemento CreateMemento()
        {
            HeroMemento Memento = new HeroMemento();
            Memento.MovementPoints = this.MovementPoints;
            Memento.RemainingMovementPoints = this.RemainingMovementPoints;
            Memento.x = this.x;
            Memento.y = this.y;
            return Memento;
        }

        public void Restore(HeroMemento Memento)
        {
            this.MovementPoints = Memento.MovementPoints;
            this.RemainingMovementPoints = Memento.RemainingMovementPoints;
            this.x = Memento.x;
            this.y = Memento.y;
        }

        public void RestoreTurn()
        {
            this.RemainingMovementPoints = this.MovementPoints;
        }

        public void SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] GetCoordinates()
        {
            return new int[] { x, y};
        }

        public int GetRemainingSteps()
        {
            return this.RemainingMovementPoints;
        }
    }
}
