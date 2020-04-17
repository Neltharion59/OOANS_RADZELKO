using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace OOANS_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Field[][] Fields = new Field[5][];
            for (int i = 0; i < Fields.Length; i++)
            {
                Fields[i] = new Field[5];
                for (int j = 0; j < Fields[i].Length; j++)
                {
                    Fields[i][j] = new Field(i, j);
                }
            }

            Battlefield Battlefield = new Battlefield(Fields.Select(x => x.ToList()).ToList());

            Fields[0][1].SetStateNew(ForestFieldState.GetInstance());
            Fields[0][3].SetStateNew(ImpassableFieldState.GetInstance());

            Fields[2][2].SetStateNew(ImpassableFieldState.GetInstance());
            Fields[2][3].SetStateNew(ImpassableFieldState.GetInstance());
            Fields[3][2].SetStateNew(ImpassableFieldState.GetInstance());
            Fields[3][3].SetStateNew(ImpassableFieldState.GetInstance());

            Fields[1][3].SetStateNew(NormalFieldState.GetInstance());
            Fields[1][4].SetStateNew(NormalFieldState.GetInstance());

            Hero Hero = new Hero(new List<Skill>(), 100, "Hero1"); 
            Hero.ActionPoints = 5;
            Hero.RemainingActionPoints = 5;
            Battlefield.AddHero(Hero, 0, 0);
            Hero = new Hero(new List<Skill>(), 50, "Hero3"); 
            Hero.ActionPoints = 4;
            Hero.RemainingActionPoints = 4;
            Battlefield.AddHero(Hero, 4, 4);
            BattleController bc = new BattleController(Battlefield);
            
            /*table
                 .AddRow("this line should be longer", "yes it is", "oh");
            table.AddRow(Temp);
            table.Write();*/

            List<object[]> a = Battlefield.ToRenderableFormat();

            String[] Placeholder = new string[a[0].Length];
            for (int i = 0; i < Placeholder.Length; i++)
            {
                Placeholder[i] = i.ToString();
            }
           var table = new ConsoleTable(Placeholder);
            foreach (object[] O in a)
            {
                table.AddRow(O);
            }
            table.Write();


            //otazky
            //ako dostat source field passive skillu do vyvolania?
        
            //vytvor skilly pre hrdinu
            List<Skill> skillList = new List<Skill>();

            //skillList.Add(new HealSkill("Basic heal", 10, 0)); 
            //PassiveSkillTriggering pst = new PassiveSkillTriggering(90, skillList.Last(), Battlefield);
            //skillList.Last().TriggerBehaviour = pst;        //todo setter pre pasivny behaviour
            skillList.Add(new HealSkill("Basic heal", 10, new SelectSelf(), 1, 1, 90, true));

            //todo vymazat, posielat hera cez notify observera
            //((PassiveSkillTriggering)skillList.Last().TriggerBehaviour).source = Battlefield.GetField(1,1);

            skillList.Add(new CauseDamageSkill("Basic attack", 10, new SelectArea(), 1, 1, 0, false));

            skillList.Add(new HealSkill("AoE heal", 10, new SelectArea(), 2, 1, 90, false));

            skillList.Add(new HealSkill("Chain heal", 10, null, 2, 4, 0, false));

            skillList.Add(new DamageDebuffSkill(new CauseDamageSkill("Fist punch", 1, new SelectOneTarget(),
                1, 1, 0, false), new DamageVulnerabilityDebuff("50% damageVulnerability", 2, 50), "Fist debuff"));

            skillList.Add(new HealBuffSkill(new HealSkill("Healing touch", 1, new SelectOneTarget(), 1, 1, 0, false),
                new DamageIncreaseBuff("Increase damage 50% buff", 2, 50), "Healing damage buff"));


            //vytvor hrdinu
            HeroInterface Hrdina = new ProxyHero(new Hero(Skills: skillList, HealthPoints: 100, name: "Hero2"));
            //pridaj hrdinu na mapu
            Battlefield.GetField(1, 1).Hero = Hrdina;

            //vytvor observera
            ObserverSubject subject = Battlefield.GetField(1, 1).Hero.GetHealthStat();
            ObserverInterface observerA = Battlefield.GetField(1, 1).Hero.GetSkill(0);
            ObserverInterface observerB = new BattleScreen();
            subject.RegisterObserver(observerA);
            subject.RegisterObserver(observerB);


            //vytvor command, odkomentovat ak je prvy skill aktviny
            //Command useSkillCommand1 = new UseSkillCommand(Battlefield.GetField(1,1).Hero.GetSkill(0), Battlefield.GetField(1,1));
            //useSkillCommand1.Execute(Battlefield);

            Command useSkillCommand2 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(1), Battlefield.GetField(1, 1), new SelectOneTarget());
            useSkillCommand2.Execute(Battlefield);
            Command useSkillCommand3 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(1), Battlefield.GetField(1, 1), new SelectArea());
            useSkillCommand3.Execute(Battlefield);
            Command useSkillCommand4 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(2), Battlefield.GetField(1, 1), new SelectArea());
            useSkillCommand4.Execute(Battlefield);
            Command useSkillCommand5 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(3), Battlefield.GetField(1, 1), new SelectAutoTarget());
            useSkillCommand5.Execute(Battlefield);

            Command useSkillCommand6 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(4), Battlefield.GetField(1, 1), new SelectOneTarget());
            useSkillCommand6.Execute(Battlefield);

            Command useSkillCommand7 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(1), Battlefield.GetField(1, 1), new SelectOneTarget());
            useSkillCommand7.Execute(Battlefield);

            Command useSkillCommand8 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(5), Battlefield.GetField(1, 1), new SelectOneTarget());
            useSkillCommand8.Execute(Battlefield);

            Command useSkillCommand9 = new UseSkillCommand(Battlefield.GetField(1, 1).Hero.GetSkill(1), Battlefield.GetField(1, 1), new SelectOneTarget());
            useSkillCommand9.Execute(Battlefield);

            //Console.WriteLine("Aktual hero hp: " + Battlefield.GetField(1, 1).Hero.GetHealthStat().ActualHP);




            Console.ReadLine();
        }
    }
}
