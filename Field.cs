﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OOANS_projekt
{
    class Field : AbstractField, Subject
    {
        public int x { get; } = -1;
        public int y { get; } = -1;

        private AbstractField NextInChain { get; set; }
        private HeroInterface Hero { get; set; }
        private FieldState State { get; set; }
        public Resource Resource { get; set; }

        private List<Observer> Observers;
        public Field(int x, int y)
        {
            this.NextInChain = NullField.GetInstance();
            this.Hero = null;
            this.State = FieldStateNormal.GetInstance();

            this.x = x;
            this.y = y;

            this.Observers = new List<Observer>();
        }

        public Resource GatherResource(int Amount)
        {
            if (this.Resource == null)
            {
                return new Resource();
            }
            
            return this.State.GatherResource(this, Amount);
        }

        public override bool MoveHero(HeroInterface Hero, AbstractField Previous)
        {
            if (NextInChain == null || Hero == null)
            {
                return false;
            }
            if (!this.State.EnterField(this, Hero))
            {
                if (Previous != null)
                {
                    Previous.SetHero(Hero);
                }
                return false;
            }

            Thread.Sleep(1000);

            this.Notify();

            this.Hero = null;

            if (Hero.IsDead())
            {
                Console.WriteLine("Field::Hero died");
                return true;
            }
            else
            {
                return this.NextInChain.MoveHero(Hero, this);
            }
        }
        public FieldMemento CreateMemento()
        {
            FieldMemento Memento = new FieldMemento();
            Memento.State = this.State;
            Memento.Resource = this.Resource == null ? null : this.Resource.CreateMemento();

            return Memento;
        }
        public void Restore(FieldMemento Memento)
        {
            this.SetStateSimple(Memento.State);

            this.NextInChain = NullField.GetInstance();
            this.Hero = null;

            this.Resource = Memento.Resource == null ? null : Memento.Resource.ProduceOrigin();
        }

        public override void SetHero(HeroInterface Hero = null)
        {
            this.Hero = Hero;
            if (Hero != null)
            {
                Hero.SetCoordinates(this.x, this.y);
            }
        }

        public String ToScreenText()
        {
            return this.State.ToScreenText() + (this.Resource == null ? "" : ("-" + this.Resource.Type.ToString()[0] + ":" + Resource.Amount));
        }

        private void SetStateSimple(FieldState State)
        {
            this.State = State;
        }
        public void SetStateNew(FieldState State)
        {
            this.State = State;
            State.ProduceResource(this);
        }

        public void Register(Observer Observer, bool Readonly)
        {
            this.Observers.Add(Observer);
        }

        public void Unregister(Observer Observer, bool Readonly)
        {
            this.Observers.Remove(Observer);
        }

        public void Notify()
        {
            for (int i = this.Observers.Count - 1; i >= 0; i--)
            {
                this.Observers[i].Update(this);
            }
        }

        public override HeroInterface GetHero()
        {
            return this.Hero;
        }

        public override void SetNextInChain(AbstractField Next)
        {
            this.NextInChain = Next;
        }
    }
}
