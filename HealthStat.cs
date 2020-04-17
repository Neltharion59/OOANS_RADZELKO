using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HealthStat : ObserverSubject //observer subjekt
    {
        public int MaximumHP { get; set; }
        public int ActualHP { get; set; }
        public override List<ObserverInterface> Observers { get; set; }
        public Hero parentHero { get; set; }

        public HealthStat(int MaximumHP, Hero parentHero)
        {
            this.MaximumHP = MaximumHP;
            this.ActualHP = MaximumHP;
            this.Observers = new List<ObserverInterface>();
            this.parentHero = parentHero;
        }

        public override void RegisterObserver(ObserverInterface observer)
        {
            if (!Observers.Contains(observer))
            {
                this.Observers.Add(observer);
            }
        }

        public override void UnregisterObserver(ObserverInterface observer)
        {
            if (Observers.Contains(observer))
            {
                this.Observers.Remove(observer);
            }
        }

        public override void NotifyObservers()
        {
            foreach (ObserverInterface observer in Observers)
            {
                observer.Update(this, this.parentHero);
            }
        }


        public void DealDamage(int amount) //todo opytat sa ci je to ok kvoli proxy?
        {
            if (amount > 0)
            {
                this.ActualHP -= amount;
                NotifyObservers();
            }
        }

        public void Heal(int amount)
        {
            if (amount > 0)
            {
                this.ActualHP += amount;
                if(this.ActualHP > MaximumHP)
                {
                    this.ActualHP = MaximumHP;
                }
                NotifyObservers();
            }
        }

    }
}
