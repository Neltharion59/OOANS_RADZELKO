using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class BattleScreen : ObserverInterface
    {
        public void Update(ObserverSubject subject, HeroInterface parentHero)
        {
            Console.WriteLine("Observer: Health of " + parentHero.GetHeroName() + " changed to: " + parentHero.GetHealthStat().ActualHP);
        }
    }
}
