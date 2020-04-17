using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class TrapObserver : Observer
    {
        private BattleController BattleController { get; }
        private Skill Skill { get; }
        private int x { get; }
        private int y { get; }
        public TrapObserver(BattleController BattleController, Skill Skill, int x, int y)
        {
            this.BattleController = BattleController;
            this.Skill = Skill;
            this.x = x;
            this.y = y;
        }
        public void Update(Subject Subject)
        {
            Console.WriteLine("Trap Triggered");
            //TODO - create use skill command
            Subject.Unregister(this, false);

            UseSkillCommand Command = new UseSkillCommand(Skill, BattleController.Battlefield.GetField(x, y), Skill.TriggerBehaviour);
            BattleController.ExecuteCommand(Command);
        }
    }
}
