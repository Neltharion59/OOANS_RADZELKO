using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class FieldStateMemento
    {
        public FieldState State { get; set; }
        public List<SkillMemento> Skills { get; }

        public FieldStateMemento()
        {
            this.State = NormalFieldState.GetInstance();
            this.Skills = new List<SkillMemento>();
        }
    }
}
