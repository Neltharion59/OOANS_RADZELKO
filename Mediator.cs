using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{

// Mediates the common tasks
public class Mediator
{
    public Controller BattleController { get; set; }
    public Controller MarketplaceController { get; set; }

    public void SwitchMode(Controller.ControllerType type)
    {
        switch (type){
            case Controller.ControllerType.Battlefield : 
                this.BattleController.Commence(type);
                break;
            case Controller.ControllerType.Marketplace : 
                this.MarketplaceController.Commence(type);
                break;
        }
    }
}}
