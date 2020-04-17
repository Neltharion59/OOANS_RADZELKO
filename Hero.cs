﻿using System;
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
        public int RemainingActionPoints { get; set; }
        public int x;
        public int y;
        public int HarvestPower;
        private HeroInventory Inventory;
        //Miso
        public List<Skill> Skills { get; set; }
        public HealthStat HP { get; set; }
        public String name { get; set; }

        public Hero(List<Skill> Skills, int HealthPoints, String name)
        {
            this.Skills = Skills;
            this.HP = new HealthStat(HealthPoints, this);
            this.name = name;
            
            
            this.ActionPoints = 0;
            this.RemainingActionPoints = 0;

            this.x = -1;
            this.y = -1;

            this.HarvestPower = 1;

            this.Inventory = new HeroInventory();
        }
        //Lukas
        public bool IsDead()
        {
            return false;
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
        public HeroMemento CreateMemento()
        {
            HeroMemento Memento = new HeroMemento();
            Memento.MovementPoints = this.ActionPoints;
            Memento.RemainingMovementPoints = this.RemainingActionPoints;
            Memento.x = this.x;
            Memento.y = this.y;
            Memento.HarvestPower = this.HarvestPower;
            return Memento;
        }

        public void Restore(HeroMemento Memento)
        {
            this.ActionPoints = Memento.MovementPoints;
            this.RemainingActionPoints = Memento.RemainingMovementPoints;
            this.x = Memento.x;
            this.y = Memento.y;
            this.HarvestPower = Memento.HarvestPower;
        }

        public void RestoreTurn()
        {
            this.RemainingActionPoints = this.ActionPoints;
        }

        public void SetCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int[] GetCoordinates()
        {
            return new int[] { x, y};
        }

        public int GetRemainingSteps()
        {
            return this.RemainingActionPoints;
        }

        public int GetHavervestPower()
        {
            return this.HarvestPower;
        }

        public bool AddResource(Resource Resource)
        {
            return this.Inventory.AddResource(Resource);
        }

        public void BoostActionPoints(int Amount)
        {
            this.RemainingActionPoints += Amount;
        }
        //Miso
        public Skill GetSkill(int id) //TODO vymyslet to inak?  nie podla id
        {
            return this.Skills[id];
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
    }
}
