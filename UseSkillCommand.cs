using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class UseSkillCommand : Command
    {
        Skill UsedSkill;
        Field source;

        public UseSkillCommand(Skill UsedSkill, Field source, ITriggerBehaviour triggerBehaviour)
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
