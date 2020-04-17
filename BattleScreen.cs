using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class BattleScreen : Observer
    {
        private HeroInterface Hero;
        public BattleScreen(HeroInterface Hero)
        {
            this.Hero = Hero;
        }
        public void Update(Subject Subject)
        {
            Console.WriteLine("HP of " + Hero.GetHeroName() + " changed to " + ((HealthStat)Subject).ActualHP);
        }
    }
}
