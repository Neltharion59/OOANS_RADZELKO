using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class ObserverPassiveSkill : Observer
    {
        private BattleController BattleController { get; }
        private Skill Skill { get; }
        private HeroInterface SkillOwner { get; }
        //private bool WasActivated;
        public ObserverPassiveSkill(BattleController BattleController, Skill Skill, HeroInterface SkillOwner)
        {
            this.BattleController = BattleController;
            this.Skill = Skill;
            this.SkillOwner = SkillOwner;

            //this.WasActivated = false;
        }
        public void Update(Subject Subject)
        {
            if (((HealthStat)Subject).ActualHP > Skill.TriggerTreshold)
            {
                return;
            }

            /*if(WasActivated)
            {
                return;
            }

            WasActivated = true;*/
            Console.WriteLine("Passive Skill Triggered");

            CommandUseSkill Command = new CommandUseSkill(Skill, BattleController.Battlefield.GetField(SkillOwner), Skill.TriggerBehaviour);
            BattleController.ExecuteCommand(Command);
        }
    }
}
