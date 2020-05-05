using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleTables;

namespace OOANS_projekt
{
    class MarketplaceController : Controller
    {
        private Inventory Armory;
        private Inventory Weaponry;
        private Inventory Consumables;
        private Inventory BuyingVendor;
        private Inventory BackPack;
    
        public void Commence(ControllerType type)
        {
            this.LoadOptions();
        }
        
        public void LoadOptions(){
            Console.WriteLine("Welcome to the RadZelKo!");
            Console.WriteLine("1: Start battle");
            Console.WriteLine("2: Go to market");
            Console.WriteLine("3: Manage heroes");
            Console.WriteLine("4: Exit");
        }
        
        public void LoadMarketplace(int place)
        {
            Inventory from;
            Inventory to;
            switch place
            {
                case 1: 
                    Mediator.SwitchMode(Controller.ControllerType.Battle);
                    break;
                case 2: 
                    Mediator.SwitchMode(Controller.ControllerType.Marketplace);
                    break;
                case 3: 
                    Mediator.SwitchMode(Controller.ControllerType.Menu);
                    break;
                default:
                    System.Halt();     
            }
        }

}}