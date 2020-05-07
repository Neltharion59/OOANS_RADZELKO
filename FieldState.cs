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

            if (!PermitEntry())
            {
                return false;
            }
            if (Field.GetHero() != null)
            {
                return false;
            }
           if (!Hero.PayActionCost(GetEntryCost()))
            {
                return false;
            }
            Field.SetHero(Hero);

            return true;
        }
        protected abstract bool PermitEntry();
        protected abstract int GetEntryCost();

        public virtual Resource GatherResource(Field Field, int Amount)
        {
            Resource Result = Field.Resource.Take(Amount);
            if (Result.Type != ResourceType.None && Field.Resource.IsDepleted())
            {
                UpdateFieldStateAfterGathering(Field);
            }

            return Result;
        }
        protected abstract void UpdateFieldStateAfterGathering(Field Field);
        public abstract void ProduceResource(Field Field);
        public abstract String ToScreenText();
    }
}
