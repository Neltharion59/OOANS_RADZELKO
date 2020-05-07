using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{

// Mediates the common tasks
class ControllerMediator : Mediator
{
        public BattleController BattleController;
        public MarketplaceController MarketplaceController;
        public Menu Menu;

        public ControllerMediator(BattleController BattleController, MarketplaceController MarketplaceController, Menu Menu)
        {
            this.BattleController = BattleController;
            this.MarketplaceController = MarketplaceController;
            this.Menu = Menu;
        }

        public void SwitchMode(Controller.ControllerType type)
    {
        switch (type){
            case Controller.ControllerType.Battle :
                    this.BattleController.Commence(type, this);
                break;
            case Controller.ControllerType.Marketplace:
                this.MarketplaceController.Commence(type, this);
                break;
            case Controller.ControllerType.Menu:
                this.Menu.Commence(type, this);
                break;

            }
        }
}}
