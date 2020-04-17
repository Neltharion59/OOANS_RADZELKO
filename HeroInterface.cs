using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface HeroInterface
    {
        //Lukas
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
        //Miso
        public Skill GetSkill(int id);
        public HealthStat GetHealthStat();
        public String GetHeroName();
        public void DealDamage(int amount);
        public void HealHealth(int amount);
        public void AddEffect(Effect effect);
        public void RemoveEffect(Effect effect);
        public double CalculateDamageModifier();

    }
}
