using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class PassiveSkillTriggering : ITriggerBehaviour, ObserverInterface
    {
        Skill skill;
        public Battlefield battlefield { get; set; }
        public Field source { get; set; }
        int triggerHealthTreshold;

        public PassiveSkillTriggering(int triggerHealthTreshold, Skill skill, Battlefield battlefield)
        {
            this.triggerHealthTreshold = triggerHealthTreshold;
            this.skill = skill;
            this.battlefield = battlefield;
        }

        public void Update(ObserverSubject subject, HeroInterface hero)
        {
            int MaxHP = ((HealthStat)subject).MaximumHP;
            int ActualHP = ((HealthStat)subject).ActualHP;
     

            if (ActualHP < triggerHealthTreshold)
            {
                //skill.Use(battlefield, targets); //todo dostat sa cez hrdinu k fieldu
            }
        }

        public void Trigger(Skill skill, Battlefield battlefield, Field source, bool selftarget) //trigger tu v podstate neni, pach odmietnute dedicstvo?
        {         
        }

    }
}
