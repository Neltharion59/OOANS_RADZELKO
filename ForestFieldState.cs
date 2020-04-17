using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class ForestFieldState : FieldState
    {
        private static ForestFieldState Instance = null;
        private ForestFieldState() { }
        public static ForestFieldState GetInstance()
        {
            if (ForestFieldState.Instance == null)
            {
                ForestFieldState.Instance = new ForestFieldState();
            }

            return ForestFieldState.Instance;
        }
        public override int GetEntryCost()
        {
            return 2;
        }

        public override bool PermitEntry()
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

        public override void UpdateFieldStateAfterGathering(Field Field)
        {
            Field.SetStateNew(NormalFieldState.GetInstance());
        }
    }
}
