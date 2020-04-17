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

        public override string ToScreenText()
        {
            return "Mt";
        }

        public override void UpdateFieldStateAfterGathering(Field Field)
        {
            Field.SetStateNew(NormalFieldState.GetInstance());
        }

        public override int GetEntryCost()
        {
            return int.MaxValue;
        }

        public override bool PermitEntry()
        {
            return false;
        }

        public override void ProduceResource(Field Field)
        {
            Field.Resource = new Resource(ResourceType.Iron, 3);
        }
    }
}
