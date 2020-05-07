using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleTables;

namespace OOANS_projekt
{
    public class MarketplaceController : Controller
    {
        private Inventory Armory = new Inventory();
        private Inventory Weaponry = new Inventory();
        private Inventory Consumables = new Inventory();
        private Inventory BuyingVendor = new Inventory();
        private Inventory BackPack = new Inventory();
        private Mediator Mediator;
    
        public void Commence(Controller.ControllerType type, Mediator Mediator)
        {
            this.Mediator = Mediator;
            Armory.AddItem(new Item(15, "helm"));
            Armory.AddItem(new Item(25, "belt"));
            Armory.AddItem(new Item(35, "glove"));
            Armory.AddItem(new Item(45, "pants"));
            Armory.AddItem(new Item(55, "boot"));


            this.LoadOptions();
        }
        
        public void LoadOptions(){
            Console.WriteLine("Welcome to the Market Place! Select what your purpose of visit:");
            Console.WriteLine("1: Buy armor");
            Console.WriteLine("2: Buy weapons");
            Console.WriteLine("3: Buy consumables");
            Console.WriteLine("4: Sell wares");
            Console.WriteLine("Literally anything else: Exit");

            string choice = Console.ReadLine();
            int numChoice;
            Console.WriteLine("");
            if (int.TryParse(choice, out numChoice))
            {
                LoadMarketplace(numChoice);
            }
            Mediator.SwitchMode(Controller.ControllerType.Menu);
            return;

            /*LoadMarketplace(3);*/
        }

        public void LoadMarketplace(int place)
        {
            Inventory from;
            Inventory to;
            switch (place)
            {
                case 1: 
                    from = Armory;
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
                    return;
     
            }
            foreach (AbstractItem Item in from.Items)
            {
                Console.WriteLine(Item.Name + ": " + Item.Price);
            }

            PriceCalculateVisitor visitor = new PriceCalculateVisitor();
            string Input = Console.ReadLine();
            int selection = int.Parse(Input) - 1;
            Console.WriteLine("");
            while (selection < from.Items.Count)
            {
                if (selection < from.Items.Count)
                {
                    AbstractItem item = from.Items.ElementAt(selection);
                    to.Money -= item.Price;
                    from.Money += item.Price;
                    to.AddItem(item);
                    from.RemoveItem(selection);

                    foreach (AbstractItem Item in from.Items)
                    {
                        Console.WriteLine(Item.Name + ": " + Item.Price);
                    }
                    Input = Console.ReadLine();
                    selection = int.Parse(Input) - 1;
                    Console.WriteLine("");
                }
            }

            SimpleIterator iterator = new SimpleIterator(to.Items);
            while(iterator.HasNext())
            {
                iterator.Next().Accept(visitor);
            }

            Console.WriteLine(visitor.value + " gold have suddenly changed hands:) ");
            Console.WriteLine("");

            LoadOptions();
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