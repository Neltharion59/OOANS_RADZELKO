using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface ObserverInterface
    {
        public void Update(ObserverSubject subject, HeroInterface parentHero);
    }
}
