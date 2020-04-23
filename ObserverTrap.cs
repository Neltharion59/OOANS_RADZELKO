using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class ObserverTrap : Observer
    {
        private BattleController BattleController { get; }
        private Skill Skill { get; }
        private int x { get; }
        private int y { get; }
        public ObserverTrap(BattleController BattleController, Skill Skill, int x, int y)
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

            CommandUseSkill Command = new CommandUseSkill(Skill, BattleController.Battlefield.GetField(x, y), Skill.TriggerBehaviour);
            BattleController.ExecuteCommand(Command);
        }
    }
}
