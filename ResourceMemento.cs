using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class ResourceMemento
    {
        public int Amount { get; set; }
        public ResourceType Type { get; set;  }

        public ResourceMemento()
        {
            this.Amount = 0;
            this.Type = ResourceType.None;
        }

        public Resource ProduceOrigin()
        {
            return new Resource(Type, Amount);
        }
    }
}
