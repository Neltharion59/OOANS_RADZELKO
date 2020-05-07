using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class FieldStateImpassable : FieldState
    {
        private static readonly int EntryCost = int.MaxValue;
        private static FieldStateImpassable Instance = null;
        private FieldStateImpassable() : base()
        {
        }
        public static FieldStateImpassable GetInstance()
        {
            if (FieldStateImpassable.Instance == null)
            {
                FieldStateImpassable.Instance = new FieldStateImpassable();
            }

            return FieldStateImpassable.Instance;
        }

        public override string ToScreenText()
        {
            return "Mt";
        }

        protected override void UpdateFieldStateAfterGathering(Field Field)
        {
            Field.SetStateNew(FieldStateNormal.GetInstance());
        }

        protected override int GetEntryCost()
        {
            return EntryCost;
        }

        protected override bool PermitEntry()
        {
            return false;
        }

        public override void ProduceResource(Field Field)
        {
            Field.Resource = new Resource(ResourceType.Iron, 3);
        }
    }
}
