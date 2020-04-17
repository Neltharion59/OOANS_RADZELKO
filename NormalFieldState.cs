using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class NormalFieldState : FieldState
    {
        private static int EntryCost = 1;
        private static NormalFieldState Instance = null;
        private NormalFieldState() : base()
        {
        }
        public static NormalFieldState GetInstance()
        {
            if (NormalFieldState.Instance == null)
            {
                NormalFieldState.Instance = new NormalFieldState();
            }

            return NormalFieldState.Instance;
        }

        public override string ToScreenText()
        {
            return "Norm";
        }

        public override void UpdateFieldStateAfterGathering(Field Field)
        {
        }

        public override int GetEntryCost()
        {
            return NormalFieldState.EntryCost;
        }

        public override bool PermitEntry()
        {
            return true;
        }
        public override void ProduceResource(Field Field)
        {
            Field.Resource = null;
        }
    }
}
