using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HealthStat : Subject //observer subjekt
    {
        public int MaximumHP { get; set; }
        public int ActualHP { get; set; }
        private List<Observer> ReadOnlyObservers { get; set; }
        private List<Observer> WriteObservers { get; set; }
        private bool IsNotificating;

        public HealthStat(int MaximumHP)
        {
            this.MaximumHP = MaximumHP;
            this.ActualHP = MaximumHP;
            this.ReadOnlyObservers = new List<Observer>();
            this.WriteObservers = new List<Observer>();
            this.IsNotificating = false;
        }

        public void Register(Observer observer, bool ReadOnly)
        {
            List<Observer> Observers = ReadOnly ? ReadOnlyObservers : WriteObservers;
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
        }

        public void Unregister(Observer observer, bool ReadOnly)
        {
            List<Observer> Observers = ReadOnly ? ReadOnlyObservers : WriteObservers;
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in this.ReadOnlyObservers)
            {
                observer.Update(this);
            }

            if (IsNotificating)
            {
                return;
            }

            IsNotificating = true;
            foreach (Observer observer in this.WriteObservers)
            {
                observer.Update(this);
            }         
        }


        public void DealDamage(int amount) //todo opytat sa ci je to ok kvoli proxy?
        {
            if (amount > 0)
            {
                this.ActualHP -= amount;
                Notify();
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
                Notify();
            }
        }

    }
}
