using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HeroInventory
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
        public HeroInventoryMemento CreateMemento()
        {
            HeroInventoryMemento Memento = new HeroInventoryMemento();
            Memento.Resources = this.Resources.Select(resource => resource.CreateMemento()).ToList();
            return Memento;
        }
        public void Restore(HeroInventoryMemento Memento)
        {
            this.Resources.Clear();
            foreach (ResourceMemento ResMemento in Memento.Resources)
            {
                this.AddResource(ResMemento.ProduceOrigin());
            }
        }
    }
}
