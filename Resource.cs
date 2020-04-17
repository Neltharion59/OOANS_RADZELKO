using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Resource
    {
        public int Amount { get; private set; }
        public ResourceType Type { get; }
        public Resource(ResourceType Type, int Amount = 0)
        {
            this.Type = Type;
            this.Amount = Amount;
        }
        public bool Add(Resource Resource)
        {
            if (!(this.Type == Resource.Type))
            {
                return false;
            }
            this.Amount += Resource.Amount;
            return true;
        }
        public Resource Take(int amount)
        {
            Resource Result;
            if (amount > 0)
            {
                int TakeAmount = amount <= this.Amount ? amount : this.Amount;
                this.Amount -= TakeAmount;
                Result = new Resource(this.Type, TakeAmount);
            }
            else
            {
                Result = new Resource(ResourceType.None);
            }
            return Result;
        }
        public Resource TakeExactly(int amount)
        {
            Resource Result;
            if (amount <= this.Amount && amount > 0)
            {
                this.Amount -= amount;
                Result = new Resource(this.Type, amount);
            }
            else
            {
                Result = new Resource(ResourceType.None);
            }
            return Result;
        }
        public bool IsDepleted()
        {
            return this.Amount <= 0 ? true : false;
        }

        public ResourceMemento CreateMemento()
        {
            ResourceMemento Memento = new ResourceMemento();
            Memento.Amount = this.Amount;
            Memento.Type = this.Type;
            return Memento;
        }

        public void Restore(ResourceMemento Memento)
        {
            if (Memento.Type == this.Type)
            {
                this.Amount = Memento.Amount;
            }
        }
    }
}
