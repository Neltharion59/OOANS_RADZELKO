using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class FieldMemento
    {
        public FieldStateMemento State { get; set; }
        public ResourceMemento Resource { get; set; }

        public FieldMemento()
        {
            this.State = NormalFieldState.GetInstance().CreateMemento();
            this.Resource = null;
        }
    }
}
