using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class CommandGather : Command
    {
        private static int HarvestActionCost = 1;
        private HeroInterface GatheringHero { get; }
        public CommandGather(HeroInterface GatheringHero)
        {
            this.GatheringHero = GatheringHero;
        }
        public override bool Execute(Battlefield Battlefield)
        {
            if (this.GatheringHero == null)
            {
                return false;
            }

            Field Field = Battlefield.GetField(GatheringHero.GetCoordinates()[0], GatheringHero.GetCoordinates()[1]);
            if(Field == null)
            {
                return false;
            }

            Resource Resource = Field.GatherResource(GatheringHero.GetHarvestPower());
            if (Resource.Type == ResourceType.None)
            {
                return false;
            }

            if (!GatheringHero.PayActionCost(HarvestActionCost))
            {
                if (Field.Resource == null)
                {
                    Field.Resource = Resource;
                }
                else
                {
                    Field.Resource.Add(Resource);
                }
                return false;
            }

            if (!GatheringHero.AddResource(Resource))
            {
                if (Field.Resource == null)
                {
                    Field.Resource = Resource;
                }
                else
                {
                    Field.Resource.Add(Resource);
                }
                GatheringHero.BoostActionPoints(HarvestActionCost);
                return false;
            }

            return true;
        }
    }
}
