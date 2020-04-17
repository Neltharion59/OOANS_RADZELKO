using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    abstract class SkillTriggering : ITriggerBehaviour
    {

        public void Trigger(Skill skill, Battlefield battlefield, Field source, bool targetSelf)
        {
            List<Field> targets;
            double coeficient;

            this.printTriggerMessage();
            this.printSkillName(skill);
            targets = this.selectTargets(skill, battlefield, source, targetSelf);
            coeficient = this.CalculateCoeficient(skill, source);
            //this.applySkillEffect(skill, battlefield, targets, coeficient);
            skill.Use(battlefield, targets, coeficient);
            this.printAfterTriggerMessage();

        }

        protected void printTriggerMessage()
        {
            Console.WriteLine("Skill triggering!");
        }

        protected void printSkillName(Skill skill)
        {
            Console.WriteLine(skill.Name);
        }

        protected abstract List<Field> selectTargets(Skill skill, Battlefield battlefield, Field source, bool targetSelf);
        protected abstract double CalculateCoeficient(Skill skill, Field source);

        protected void applySkillEffect(Skill skill, Battlefield battlefield, List<Field> targets, double coeficient)
        {
            skill.Use(battlefield, targets, coeficient);
        }

        protected void printAfterTriggerMessage()
        {
            Console.WriteLine("End of skill!\n");
        }

    }
}
