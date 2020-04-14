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
        public HeroInterface Hero { get; set; }
        public Field()
        {
            this.NextInChain = NullField.GetInstance();
            this.Hero = null;
        }

        public override bool MoveHero(HeroInterface Hero, Field Previous = null)
        {
            if (NextInChain == null || Hero == null)
            {
                return false;
            }

            this.Hero = Hero;

            Console.WriteLine("Hero is here: " + this.x + ", " + this.y);
           // Thread.Sleep(1000);

            this.Hero = null;

            return this.NextInChain.MoveHero(Hero, this);
        }
    }
}
