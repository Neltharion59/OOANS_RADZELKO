using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class Skill : ObserverInterface
    {
        public String Name { get; set; }
        public int Range { get; set; }
        public int MaxTargets { get; set; }
        public bool Passive { get; set; }
        public int TriggerTreshold { get; set; }
        public ITriggerBehaviour TriggerBehaviour { get; set; }
    
        public abstract void Use(Battlefield battlefield, List<Field> targets, double coeficient);
        public abstract void Trigger(Battlefield battlefield, Field source);
        public abstract void Update(ObserverSubject subject, HeroInterface parentHero);
        
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
