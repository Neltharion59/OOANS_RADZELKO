using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class FieldState
    {
        public bool EnterField(Field Field, HeroInterface Hero)
        {

            Console.WriteLine("FieldState::EnterField - permit entry");
            if (!PermitEntry())
            {
                return false;
            }
            Console.WriteLine("FieldState::EnterField - blocking hero check");
            if (Field.Hero != null)
            {
                return false;
            }
            Console.WriteLine("FieldState::EnterField - move cost");
            if (!Hero.Move(GetEntryCost()))
            {
                return false;
            }
            Console.WriteLine("FieldState::EnterField - traps");
            Field.SetHero(Hero);

            TriggerTraps(Hero);
            if (Hero.IsDead())
            {
                Field.SetHero();
            }
            Console.WriteLine("FieldState::EnterField - update field state");
            UpdateFieldState(Field);

            return true;
        }

        protected abstract bool PermitEntry();
        protected abstract void TriggerTraps(HeroInterface Hero);
        protected abstract int GetEntryCost();
        protected abstract void UpdateFieldState(Field Field);

        public virtual FieldStateMemento CreateMemento()
        {
            FieldStateMemento Memento = new FieldStateMemento();
            Memento.State = this;
            return Memento;
        }
        public virtual void Restore(FieldStateMemento Memento)
        {
        }
    }
}
