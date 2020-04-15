using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OOANS_projekt
{
    class Field : AbstractField
    {
        //TODO
        public int x = -1;
        public int y = -1;

        public AbstractField NextInChain { get; set; }
        public HeroInterface Hero { get; private set; }
        public FieldState State { get; set;}
        public Field()
        {
            this.NextInChain = NullField.GetInstance();
            this.Hero = null;
            this.State = NormalFieldState.GetInstance();
        }

        public override bool MoveHero(HeroInterface Hero, Field Previous)
        {
            Console.WriteLine("Field::MoveHero - check for null hero");
            if (NextInChain == null || Hero == null)
            {
                return false;
            }
            Console.WriteLine("Field::MoveHero - state check");
            if (!this.State.EnterField(this, Hero))
            {
                if (Previous != null)
                {
                    Console.WriteLine("Set hero to previous");
                    Previous.SetHero(Hero);
                }
                return false;
            }

            Thread.Sleep(1000);

            this.Hero = null;
            Console.WriteLine("Field::MoveHero - next");
            return this.NextInChain.MoveHero(Hero, this);
        }
        public FieldMemento CreateMemento()
        {
            FieldMemento Memento = new FieldMemento();
            Memento.State = this.State.CreateMemento();

            return Memento;
        }
        public void Restore(FieldMemento Memento)
        {
            this.State = Memento.State.State;
            this.State.Restore(Memento.State);

            this.NextInChain = NullField.GetInstance();
            this.Hero = null;
        }

        public void SetHero(HeroInterface Hero)
        {
            this.Hero = Hero;
            Hero.SetCoordinates(this.x, this.y);
        }
        public void SetHero()
        {
            this.Hero = null;
        }

        public String ToScreenText()
        {
            return this.State.ToScreenText();
        }
    }
}
