﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SelectSelf : ITriggerBehaviour
    {
        public double CalculateCoeficient(Field source, int MaxTargets)
        {
            return 1.0 * source.Hero.CalculateDamageModifier();
        }

        public List<Field> selectTargets(Battlefield battlefield, Field source, int SkillRange, int MaxTargets, bool targetSelf)
        {
            List<Field> targets = new List<Field>
            {
                source
            };

            return targets;
        }
    }
}