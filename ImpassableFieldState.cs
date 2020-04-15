using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class ImpassableFieldState : FieldState
    {
        private static ImpassableFieldState Instance = null;
        private ImpassableFieldState() : base()
        {
        }
        public static ImpassableFieldState GetInstance()
        {
            if (ImpassableFieldState.Instance == null)
            {
                ImpassableFieldState.Instance = new ImpassableFieldState();
            }

            return ImpassableFieldState.Instance;
        }

        protected override int GetEntryCost()
        {
            return int.MaxValue;
        }

        protected override bool PermitEntry()
        {
            return false;
        }

        protected override void TriggerTraps(HeroInterface Hero)
        {
        }

        protected override void UpdateFieldState(Field Field)
        {
        }
    }
}
