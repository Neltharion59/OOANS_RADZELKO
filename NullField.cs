using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class NullField : AbstractField
    {
        private static NullField Instance { get; set; } = null;
        private NullField()
        {
        }
        public static NullField GetInstance()
        {
            if (NullField.Instance == null)
            {
                NullField.Instance = new NullField();
            }
            return NullField.Instance;
        }

        public override bool MoveHero(HeroInterface Hero, Field Previous)
        {
            bool Result = false;
            if (Previous != null && Hero != null)
            {
                Previous.SetHero(Hero);
                Result = true;
            }
            return Result;
        }
    }
}
