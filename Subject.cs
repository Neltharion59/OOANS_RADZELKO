using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface Subject
    {
        void Register(Observer Observer);
        void Unregister(Observer Observer);
        void Notify();
    }
}
