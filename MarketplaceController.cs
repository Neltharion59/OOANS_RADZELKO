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
            Console.WriteLine("Welcome to the Market Place! Select what your purpose of visit:");
            Console.WriteLine("1: Buy armor");
            Console.WriteLine("2: Buy weapons");
            Console.WriteLine("3: Buy consumables");
            Console.WriteLine("4: Sell wares");
            Console.WriteLine("5: Exit");
            
            /*LoadMarketplace(3);*/
        }
        
        public void LoadMarketplace(int place)
        {
            Inventory from;
            Inventory to;
            switch place
            {
                case 1: 
                    from = this.Armory;
                    to = this.BackPack;
                    break;
                case 2: 
                    from = this.Weaponry;
                    to = this.BackPack;
                    break;
                case 3: 
                    from = this.Consumables;
                    to = this.BackPack;
                    break;
                case 4:
                    from = this.BackPack;
                    to = this.BuyingVendor;           
                    break;
                default:
                    Mediator.SwitchMode(Controller.ControllerType.Menu);
     
            }
            foreach (Item item in from.GetItems())
            {
                Console.WriteLine(item.Name + ": " + item.Price);
            }
            
            /*
            int[] selections = [1, 2, 5];
            foreach (int selection in selections)
            {
                Item item = (from.GetItems())[selection];
                to.setMoney(to.getMoney - item.price);
                from.setMoney(from.getMoney + item.price);
                to.AddItem(item);
                from.RemoveItem(selection);
            } 
            */
        }
        void doAction()
        {
            /*Iterator Iterator = Consumables.createIterator();
            ItemVisitor Visitor = new ItemVisitor();
            while (Iterator.HasNext())
            {
                Iterator.Next().visit(Visitor);
            }

            Visitor.getResult()*/
        }

}}