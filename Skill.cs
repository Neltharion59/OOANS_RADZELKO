using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class Skill
    {
        public String Name { get; set; }
        public int Range { get; set; }
        public int MaxTargets { get; set; }
        public bool Passive { get; set; }
        public int TriggerTreshold { get; set; }
        public ITriggerBehaviour TriggerBehaviour { get; set; }
    
        
        public void Trigger(Battlefield battlefield, Field source)
        {
            Console.WriteLine("Skill is triggering: " + Name);

            List<Field> TargetFields = this.TriggerBehaviour.selectTargets(battlefield, source, this.Range, this.MaxTargets, this.TargetSelf());
            double Coefficient = this.TriggerBehaviour.CalculateCoeficient(source, this.MaxTargets);

            this.Use(TargetFields, Coefficient);

            Console.WriteLine("Skill ended: " + Name + "\n");
        }
        public abstract void Use(List<Field> targets, double coeficient);
        public abstract bool TargetSelf();
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
