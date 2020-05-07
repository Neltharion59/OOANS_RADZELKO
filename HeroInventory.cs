using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HeroInventory : Inventory
    {
        private List<Resource> Resources { get; }
        public HeroInventory()
        {
            this.Resources = new List<Resource>();
        }
        public bool AddResource(Resource Resource)
        {
            if (Resource.IsDepleted())
            {
                return false;
            }

            foreach (Resource CurrentResource in this.Resources)
            {
                if (CurrentResource.Add(Resource))
                {
                    return true;
                }
            }

            this.Resources.Add(Resource);
            return true;
        }
    }
}
