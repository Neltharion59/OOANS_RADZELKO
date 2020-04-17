using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class CauseDamageSkill : Skill
    {
        //public override string Effect { get; set; }
        //public override ITriggerBehaviour TriggerBehaviour { get; set; }
        public int DamageAmount { get; set; }

        public CauseDamageSkill(String Effect, int DamageAmount, ITriggerBehaviour TriggerBehaviour, int range, int maxTargets, int Treshold, bool pass)
        {
            this.Name = Effect;
            this.DamageAmount = DamageAmount;
            this.TriggerBehaviour = TriggerBehaviour;
            this.Range = range;
            this.MaxTargets = maxTargets;
            this.TriggerTreshold = Treshold;
            this.Passive = pass;
        }

        public override void Trigger(Battlefield battlefield, Field source)
        {
            TriggerBehaviour.Trigger(this, battlefield, source, false);
        }

        public override void Use(Battlefield battlefield, List<Field> targets, double coeficient)
        {
            foreach (Field target in targets)
            {
                if (target.Hero != null)
                {
                    //Console.WriteLine("Dealing " + (int)(DamageAmount * coeficient) + " damage to " + target.Hero.GetHeroName());
                    Console.Write("Dealing damage to " + target.Hero.GetHeroName());
                    //Console.WriteLine("\nCauseDamageSkill coeficient: " + coeficient + " damage amount: " + DamageAmount);
                    target.Hero.DealDamage((int)(DamageAmount * coeficient));

                }
            }
        }

        public override void Update(ObserverSubject subject, HeroInterface parentHero)
        {
            if (this.Passive) //tato podmienka tu teoreticky byt nemusi kedze active skill nebude registrovany u subjekta
            {
                int MaxHP = ((HealthStat)subject).MaximumHP;
                int ActualHP = ((HealthStat)subject).ActualHP;

                if (ActualHP < this.TriggerTreshold)
                {
                    Console.WriteLine("akoze passive dmg skill triggered, TODO, observer funguje");
                    //this.Trigger(battlefield: battlefield, Field: source);  //todo dostat sa cez hrdinu k fieldu

                }
            }
        }

    }
}
