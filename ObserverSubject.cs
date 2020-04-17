using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class ObserverSubject
    {
        public abstract List<ObserverInterface> Observers { get; set; }
        public abstract void RegisterObserver(ObserverInterface observer);
        public abstract void UnregisterObserver(ObserverInterface observer);
        public abstract void NotifyObservers();
    }
}
