using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleTables;

namespace OOANS_projekt
{
    class Menu : Controller
    {
        private Mediator Mediator;

        public void Commence(Controller.ControllerType type, Mediator Mediator)
        {
            this.Mediator = Mediator;
            this.LoadOptions();
        }
        
        public void LoadOptions(){
            Console.WriteLine("Welcome to the RadZelKo!");
            Console.WriteLine("1: Start battle");
            Console.WriteLine("2: Go to market");
            Console.WriteLine("3: Manage heroes");
            Console.WriteLine("4: Exit");

            string choice = Console.ReadLine();
            int numChoice;
            if (int.TryParse(choice, out numChoice))
            {
                LoadMarketplace(numChoice);
            }

        }

        public void LoadMarketplace(int place)
        {
            switch (place)
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
                    return;
            }
        }

}}