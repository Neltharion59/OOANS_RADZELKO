﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HeroMemento
    {
        public int MovementPoints { get; set; }
        public int RemainingMovementPoints { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int HarvestPower { get; set; }

        public int damageResistance { get; set; }
        public int damageVulnerability { get; set; }
        public int damageIncrease { get; set; }
        public int damageReduce { get; set; }
    }
}
