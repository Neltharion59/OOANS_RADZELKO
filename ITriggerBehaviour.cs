using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    interface ITriggerBehaviour
    {
        public List<Field> selectTargets(Battlefield battlefield, Field source, int SkillRange, int MaxTargets, bool targetSelf);
        public double CalculateCoeficient(Field source, int MaxTargets);
    }
}
