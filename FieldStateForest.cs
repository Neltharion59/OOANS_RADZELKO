using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class FieldStateForest : FieldState
    {
        private static readonly int EntryCost = 2;
        private static FieldStateForest Instance = null;
        private FieldStateForest() { }
        public static FieldStateForest GetInstance()
        {
            if (FieldStateForest.Instance == null)
            {
                FieldStateForest.Instance = new FieldStateForest();
            }

            return FieldStateForest.Instance;
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
            Field.Resource = new Resource(ResourceType.Wood, 5);
        }

        public override string ToScreenText()
        {
            return "For";
        }

        protected override void UpdateFieldStateAfterGathering(Field Field)
        {
            Field.SetStateNew(FieldStateNormal.GetInstance());
        }
    }
}
