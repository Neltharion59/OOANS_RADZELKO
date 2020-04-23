using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class ObserverFactory
    {
        private static ObserverFactory Instance = null;
        private BattleController BattleController { get; set; }
        private ObserverFactory()
        {
            this.BattleController = null;
        }
        public static ObserverFactory GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ObserverFactory();
            }
            return Instance;
        }
        public void Init(BattleController BattleController)
        {
            this.BattleController = BattleController;
        }
        public void Finish()
        {
            this.BattleController = null;
        }

        public Observer RequestObserver(HeroInterface Hero)
        {
            BattleScreenHeroHealthBar Observer = new BattleScreenHeroHealthBar(Hero);
            return Observer;
        }
        public Observer RequestObserver(Skill Skill, HeroInterface OwningHero)
        {
            ObserverPassiveSkill Observer = new ObserverPassiveSkill(this.BattleController, Skill, OwningHero);
            return Observer;
        }
        public Observer RequestObserver(Skill Skill, int x, int y)
        {
            ObserverTrap Observer = new ObserverTrap(this.BattleController, Skill, x, y);
            return Observer;
        }
    }
}
