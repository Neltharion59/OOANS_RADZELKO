using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class PassiveSkillObserver : Observer
    {
        private BattleController BattleController { get; }
        private Skill Skill { get; }
        private HeroInterface SkillOwner { get; }
        public PassiveSkillObserver(BattleController BattleController, Skill Skill, HeroInterface SkillOwner)
        {
            this.BattleController = BattleController;
            this.Skill = Skill;
            this.SkillOwner = SkillOwner;
        }
        public void Update(Subject Subject)
        {
            Console.WriteLine("Passive Skill Triggered");
            //TODO - create use skill command
        }
    }
}
