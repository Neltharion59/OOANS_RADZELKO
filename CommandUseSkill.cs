using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class CommandUseSkill : Command
    {
        private Skill UsedSkill { get; }
        private Field source { get; }

        public CommandUseSkill(Skill UsedSkill, Field source, ITriggerBehaviour triggerBehaviour)
        {
            this.UsedSkill = UsedSkill;
            this.source = source;
            this.UsedSkill.TriggerBehaviour = triggerBehaviour;
        }

        public override bool Execute(Battlefield Battlefield)
        {
            UsedSkill.Trigger(Battlefield, source);

            return true;
        }
    }
}
