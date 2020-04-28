using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class Hero : HeroInterface
    {
        //Lukas
        public int ActionPoints { get; set; }
        public int HarvestPower;
        private HeroInventory Inventory;
        //Miso
        public List<Skill> Skills { get; set; }
        public HealthStat HP { get; set; }
        public String name { get; set; }

        public Hero(List<Skill> Skills, int HealthPoints, String name)
        {
            this.Skills = Skills;
            this.HP = new HealthStat(HealthPoints);
            this.name = name;
            
            
            this.ActionPoints = 0;

            this.HarvestPower = 1;

            this.Inventory = new HeroInventory();
        }
        //Lukas
        public bool IsDead()
        {
            return false;
        }

        public bool PayActionCost(int ActionCost) { return true; }
        public HeroMemento CreateMemento()
        {
            HeroMemento Memento = new HeroMemento();
            Memento.MovementPoints = this.ActionPoints;

            Memento.HarvestPower = this.HarvestPower;
            return Memento;
        }

        public void Restore(HeroMemento Memento)
        {
            this.ActionPoints = Memento.MovementPoints;

            this.HarvestPower = Memento.HarvestPower;
        }

        public void RestoreTurn() {}

        public void SetCoordinates(int x, int y) { }

        public int[] GetCoordinates()
        {
            return null;
        }

        public int GetRemainingSteps()
        {
            return -1;
        }

        public int GetHarvestPower()
        {
            return this.HarvestPower;
        }

        public bool AddResource(Resource Resource)
        {
            return this.Inventory.AddResource(Resource);
        }

        public void BoostActionPoints(int Amount) {}
        //Miso
        public Skill GetSkill(int id) //TODO vymyslet to inak?  nie podla id
        {
            Skill Result = null;
            if (id >= 0 && id < this.Skills.Count)
            {
                Result = this.Skills[id];
            }
            return Result;
        }

        public HealthStat GetHealthStat()
        {
            return this.HP;
        }

        public String GetHeroName()
        {
            return this.name;
        }

        public void DealDamage(int amount)
        {
            this.HP.DealDamage(amount);
        }

        public void HealHealth(int amount)
        {
            this.HP.Heal(amount);
        }

        public void AddEffect(Effect effect)
        {
            
        }

        public void RemoveEffect(Effect effect)
        {
            
        }

        public double CalculateDamageModifier()
        {
            return 1.0;
        }

        public List<Skill> GetAllPasiveSkills()
        {
            List<Skill> Result = new List<Skill>();
            foreach (Skill Skill in this.Skills)
            {
                if (Skill.Passive)
                {
                    Result.Add(Skill);
                }
            }
            return Result;
        }
    }
}
