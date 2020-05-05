using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleTables;

namespace OOANS_projekt
{
    class BattleController : Controller
    {
        public Battlefield Battlefield { get; }
        public bool RefreshBattleField { get; set; }
        private readonly object Refreshlock = new object();
        private bool Over { get; set; }

        private Stack<BattlefieldMemento> CommandStackNormal { get; }
        private Stack<BattlefieldMemento> CommandStackReverse { get; }

        private LinkedList<HeroInterface> HeroQueue { get; set; }
        
        void Commence(ControllerType type)
        {
            this.RenderBattleField();
        }
        public BattleController(Battlefield Battlefield)
        {  
            this.Over = false;
            ObserverFactory.GetInstance().Init(this);

            this.Battlefield = Battlefield;

           /* Hero Hero = new Hero(new List<Skill>(), 100, "Hero1");
            Hero.ActionPoints = 5;

            Hero.Skills.Add(
                new SkillDamage(
                    "Passive self damage",
                    20,
                    SelectSelf.GetInstance(),
                    1,
                    1,
                    90,
                    true
                )
            );
            Hero.Skills.Add(
                new SkillHeal(
                    "Passive self healing",
                    20,
                    SelectSelf.GetInstance(),
                    1,
                    1,
                    80,
                    true
                )
            );


            HeroProxy Herop = new HeroProxy(Hero);
            Battlefield.AddHero(Herop, 0, 0);

            Hero = new Hero(new List<Skill>(), 50, "Hero3");
            Hero.ActionPoints = 4;
            Herop = new HeroProxy(Hero);
            Battlefield.AddHero(Herop, 4, 4);*/

            this.CommandStackNormal = new Stack<BattlefieldMemento>();
            this.CommandStackReverse = new Stack<BattlefieldMemento>();
            

            

            this.RefreshBattleField = false;
            //this.RenderBattleField();
            this.KeepRenderingBattleField();

            

            /*SkillPlaceTrap Skill = new SkillPlaceTrap(
                new SkillDamage("Pascokiller", 20, SelectSelf.GetInstance(), 1, 1, 50, false),
                "Trapp-Placing skill",
                SelectOneTarget.GetInstance(),
                1,
                1,
                20,
                false
            );
            this.ExecuteCommand(new CommandUseSkill(Skill, Battlefield.GetField(0, 0), SelectOneTarget.GetInstance()));*/
        }

        public void ReceiveCommands()
        {
            this.HeroQueue = this.Battlefield.GetAllHeroes();
            this.CommandStackNormal.Push(this.Battlefield.CreateMemento());
            this.RenderBattleField();

            String CommandInput;
            String[] Tokens;
            
            while (true)
            {
                CommandInput = Console.ReadLine();
                Tokens = CommandInput.Split(' ');
                switch (Tokens[0])
                {
                    case "move":
                        if (Tokens.Length != 2)
                        {
                            Console.WriteLine("Invalid syntax");
                            continue;
                        }
                        List<(int, int)> Coordinates = new List<(int, int)>();
                        int start_x = this.HeroQueue.First().GetCoordinates()[0];
                        int start_y = this.HeroQueue.First().GetCoordinates()[1];

                        if (Tokens[1].Split(',').Count() != 2)
                        {
                            Console.WriteLine("Invalid syntax");
                            continue;
                        }
                        int end_x = int.Parse(Tokens[1].Split(',')[0]);
                        int end_y = int.Parse(Tokens[1].Split(',')[1]);

                        int x_incerement = start_x < end_x ? 1 : -1;
                        int y_incerement = start_y < end_y ? 1 : -1;

                        int i = start_x;
                        int j = start_y;
                        while (i != end_x)
                        {
                            Coordinates.Add((i, j));
                            i += x_incerement;
                        }
                        while (j != end_y)
                        {
                            Coordinates.Add((i, j));
                            j += y_incerement;
                        }
                        Coordinates.Add((i, j));
                        Console.WriteLine(Coordinates.Count + " coordinates");

                        Command MoveCommand = new CommandMove(Coordinates);

                        lock (Refreshlock)
                        {
                            RefreshBattleField = true;
                            Monitor.PulseAll(Refreshlock);
                        }
                        this.ExecuteCommand(MoveCommand);
                        lock (Refreshlock)
                        {
                            RefreshBattleField = false;
                        }
                        Thread.Sleep(500);
                        this.RenderBattleField();
                        break;
                    case "skill":
                        if (Tokens.Length != 3)
                        {
                            Console.WriteLine("Invalid syntax - need 3 params");
                            continue;
                        }

                        int SkillID = -1;
                        if (!int.TryParse(Tokens[1], out SkillID))
                        {
                            Console.WriteLine("Invalid syntax - param 1 must be integer");
                            continue;
                        }

                        Skill Skill = HeroQueue.First().GetSkill(SkillID);
                        if(Skill == null)
                        {
                            Console.WriteLine("Skill with id " + SkillID + " does not exist");
                            continue;
                        }

                        if (Skill.Passive)
                        {
                            Console.WriteLine("Cannot actively use passive skill");
                            continue;
                        }

                        ITriggerBehaviour TargetingStrategy = null;
                        switch (Tokens[2])
                        {
                            case "one":
                                TargetingStrategy = SelectOneTarget.GetInstance();
                                break;
                            case "auto":
                                TargetingStrategy = SelectAutoTarget.GetInstance();
                                break;
                            case "area":
                                TargetingStrategy = SelectArea.GetInstance();
                                break;
                            case "self":
                                TargetingStrategy = SelectSelf.GetInstance();
                                break;
                            default:
                                break;
                        }
                        if (TargetingStrategy == null)
                        {
                            Console.WriteLine("Invalid target strategy option");
                            continue;
                        }

                        Command UseSkillCommand = new CommandUseSkill(Skill, Battlefield.GetField(HeroQueue.First().GetCoordinates()[0], HeroQueue.First().GetCoordinates()[1]), TargetingStrategy);
                        this.ExecuteCommand(UseSkillCommand);
                        this.RenderBattleField();
                        break;
                    case "gather":
                        Command GatherCommand = new CommandGather(this.HeroQueue.First());
                        this.ExecuteCommand(GatherCommand);
                        this.RenderBattleField();
                        break;
                    case "end":
                        this.CommandStackNormal.Clear();
                        this.CommandStackNormal.Push(this.Battlefield.CreateMemento());
                        this.CommandStackReverse.Clear();

                        HeroInterface Temp = this.HeroQueue.First();
                        Temp.RestoreTurn();
                        this.HeroQueue.RemoveFirst();
                        this.HeroQueue.AddLast(Temp);

                        this.RenderBattleField();

                        break;
                    case "undo":
                        if (this.CommandStackNormal.Count > 1)
                        {
                            this.CommandStackReverse.Push(this.CommandStackNormal.Pop());
                            this.Battlefield.Restore(this.CommandStackNormal.Peek());
                            this.RenderBattleField();
                        }
                        break;
                    case "redo":
                        if (this.CommandStackReverse.Any())
                        {
                            this.CommandStackNormal.Push(this.CommandStackReverse.Pop());
                            this.Battlefield.Restore(this.CommandStackNormal.Peek());
                            this.RenderBattleField();
                        }
                        break;
                    case "refresh":
                        this.RenderBattleField();
                        break;
                    case "exit":
                        this.Over = true;
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }

                if (Over)
                {
                    lock (Refreshlock)
                    {
                        Monitor.PulseAll(Refreshlock);
                    }
                    break;
                }
            }

            ObserverFactory.GetInstance().Finish();
        }
        public void ExecuteCommand(Command Command)
        {      
            Command.Execute(this.Battlefield);
            this.CommandStackNormal.Push(this.Battlefield.CreateMemento());
        }

        public void KeepRenderingBattleField()
        {
            Thread thread = new Thread(() => {
                while (true)
                {
                    lock (Refreshlock)
                    {
                        while (!RefreshBattleField)
                        {
                            if (Over)
                            {
                                break;
                            }
                            Monitor.Wait(Refreshlock);
                        }
                    }
                    if (Over)
                    {
                        break;
                    }

                    RenderBattleField();
                    
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
        }
        public void RenderBattleField()
        {
            //Console.Clear();
            List<object[]> a = Battlefield.ToRenderableFormat();

            String[] Placeholder = new string[a[0].Length];
            Placeholder[0] = "";
            for (int i = 1; i < Placeholder.Length; i++)
            {
                Placeholder[i] = (i - 1).ToString();
            }
            var table = new ConsoleTable(Placeholder);
            foreach (object[] O in a)
            {
                table.AddRow(O);
            }
            table.Write();
            if (HeroQueue.Count > 0)
            {
                Console.WriteLine("Remaining steps: " + this.HeroQueue.First().GetRemainingSteps());
            }
        }
    }
}
