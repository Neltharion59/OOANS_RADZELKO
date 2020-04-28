using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class HeroProxy : HeroInterface
    {
        public Hero RealHero { get; set; }
        public List<Effect> Effects { get; set; } //TODO naco nam je potom toto, ked vyprsi efekt tak potom vdaka tomuto bude vediet co odratat,
        public int damageResistance { get; set; }                                       //napr. dalsim observerom na konci kola....
        public int damageVulnerability { get; set; }
        public int damageIncrease { get; set; }
        public int damageReduce { get; set; }
        private int RemainingActionPoints { get; set; }
        public int x;
        public int y;
        public HeroProxy(Hero Hero)
        {
            this.RealHero = Hero;
            this.Effects = new List<Effect>();
            this.damageResistance = 0;
            this.damageVulnerability = 0;

            this.x = -1;
            this.y = -1;
            this.RemainingActionPoints = RealHero.ActionPoints;
        }

        public Skill GetSkill(int id)
        {
            return this.RealHero.GetSkill(id);
        }

        public HealthStat GetHealthStat()
        {
            return this.RealHero.GetHealthStat(); //todo aplikovanie efektu, ziaden effekt s tymto nepracuje        
        }

        public String GetHeroName()
        {
            return this.RealHero.GetHeroName();
        }

        public void DealDamage(int amount)
        {
            Console.WriteLine(": " + amount * (100 - this.damageResistance - -this.damageVulnerability) / 100);
            //Console.WriteLine("amount: " + amount);
            this.RealHero.DealDamage(amount * (100 - this.damageResistance - -this.damageVulnerability) / 100); // aplikovanie efektu
        }

        public void HealHealth(int amount)
        {
            this.RealHero.HealHealth(amount); //todo aplikovanie efektu, ziaden effekt s tymto nepracuje 
        }

        public void AddEffect(Effect effect) 
        {
            if (this.Effects.Contains(effect))
            {
                this.RemoveEffect(effect);    //TODO aby sa refreshol duration?...
                this.Effects.Add(effect);
            }
            effect.Apply(this);
        }

        public void RemoveEffect(Effect effect)
        {
            this.Effects.Remove(effect);
        }

        public double CalculateDamageModifier()
        {
            //Console.WriteLine("proxy coef: " + (1.0 + (this.damageIncrease / 100.0 - this.damageReduce / 100.0)));
            //Console.WriteLine("damageIncrease: " + this.damageIncrease);
            return  1.0 + (this.damageIncrease/100.0 - this.damageReduce/100.0);
        }

        public bool PayActionCost(int ActionCost)
        {
            if (ActionCost > RemainingActionPoints)
            {
                return false;
            }
            RemainingActionPoints -= ActionCost;
            return true;
        }

        public void BoostActionPoints(int Amount)
        {
            this.RemainingActionPoints += Amount;
        }

        public bool IsDead()
        {
            return RealHero.IsDead();
        }

        public HeroMemento CreateMemento()
        {
            HeroMemento Memento =  this.RealHero.CreateMemento();

            Memento.x = this.x;
            Memento.y = this.y;
            Memento.RemainingMovementPoints = this.RemainingActionPoints;

            Memento.damageIncrease = this.damageIncrease;
            Memento.damageReduce = this.damageReduce;
            Memento.damageResistance = this.damageResistance;
            Memento.damageVulnerability = this.damageVulnerability;

            return Memento;
        }

        public void Restore(HeroMemento Memento)
        {
            this.RealHero.Restore(Memento);

            this.x = Memento.x;
            this.y = Memento.y;
            this.RemainingActionPoints = Memento.RemainingMovementPoints;

            this.damageIncrease = Memento.damageIncrease;
            this.damageReduce = Memento.damageReduce;
            this.damageResistance = Memento.damageResistance;
            this.damageVulnerability = Memento.damageVulnerability;
        }

        public void RestoreTurn()
        {
            this.RemainingActionPoints = this.RealHero.ActionPoints;
        }

        public void SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] GetCoordinates()
        {
            return new int[] { x, y };
        }

        public int GetRemainingSteps()
        {
            return this.RemainingActionPoints;
        }

        public int GetHarvestPower()
        {
            return this.RealHero.GetHarvestPower();
        }

        public bool AddResource(Resource Resource)
        {
            return this.RealHero.AddResource(Resource);
        }

        public List<Skill> GetAllPasiveSkills()
        {
            return this.RealHero.GetAllPasiveSkills();
        }
    }
}
