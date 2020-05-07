using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class FieldStateNormal : FieldState
    {
        private static readonly int EntryCost = 1;
        private static FieldStateNormal Instance = null;
        private FieldStateNormal() : base()
        {
        }
        public static FieldStateNormal GetInstance()
        {
            if (FieldStateNormal.Instance == null)
            {
                FieldStateNormal.Instance = new FieldStateNormal();
            }

            return FieldStateNormal.Instance;
        }

        public override string ToScreenText()
        {
            return "Norm";
        }

        protected override void UpdateFieldStateAfterGathering(Field Field)
        {
        }

        protected override int GetEntryCost()
        {
            return EntryCost;
        }

        protected override bool PermitEntry()
        {
            return true;
        }
        public override void ProduceResource(Field Field)
        {
            Field.Resource = null;
        }
    }
}
