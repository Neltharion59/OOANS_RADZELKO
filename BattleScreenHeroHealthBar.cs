using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class BattleScreenHeroHealthBar : Observer
    {
        private HeroInterface Hero;
        public BattleScreenHeroHealthBar(HeroInterface Hero)
        {
            this.Hero = Hero;
        }
        public void Update(Subject Subject)
        {
            Console.WriteLine("HP of " + Hero.GetHeroName() + " changed to " + ((HealthStat)Subject).ActualHP);
        }
    }
}
