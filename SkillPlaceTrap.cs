using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class SkillPlaceTrap : Skill
    {
        private Skill TrapSkill { get; }
        public SkillPlaceTrap(Skill TrapSkill, String Name, ITriggerBehaviour TriggerBehaviour, int range, int maxTargets, int Treshold, bool pass)
        {
            this.TrapSkill = TrapSkill;

            this.Name = Name;
            this.TriggerBehaviour = TriggerBehaviour;
            this.Range = range;
            this.MaxTargets = maxTargets;
            this.TriggerTreshold = Treshold;
            this.Passive = pass;
        }
        protected override bool TargetSelf()
        {
            return true;
        }

        public override void Use(List<Field> targets, double coeficient)
        {
            foreach (Field Field in targets)
            {
                Field.Register(ObserverFactory.GetInstance().RequestObserver(TrapSkill, Field.x, Field.y), false);
            }
        }
    }
}
