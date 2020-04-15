using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class Skill
    {
        public void Use(HeroInterface Target)
        {

        }
        public virtual SkillMemento CreateMemento()
        {
            SkillMemento Memento = new SkillMemento();
            Memento.Skill = this;
            return Memento;
        }
        public virtual Skill Restore(SkillMemento Memento)
        {
            return this;
        }
    }
}