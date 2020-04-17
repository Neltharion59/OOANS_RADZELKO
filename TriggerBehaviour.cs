using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface ITriggerBehaviour
    {
        public void Trigger(Skill skill, Battlefield battlefield, Field field, bool targetSelf);
    }
}
