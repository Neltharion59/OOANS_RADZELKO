using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class TrappedFieldState : FieldState
    {
        private static readonly int EntryCost = 1;
        public List<Skill> Trapps { get; set; }

        public TrappedFieldState()
        {
            this.Trapps = new List<Skill>();
        }
        protected override int GetEntryCost()
        {
            return TrappedFieldState.EntryCost;
        }

        protected override bool PermitEntry()
        {
            return true;
        }

        protected override void TriggerTraps(HeroInterface Hero)
        {
            while (this.Trapps.Any())
            {
                if (Hero.IsDead())
                {
                    break;
                }
                this.Trapps.First().Use(Hero);
                this.Trapps.RemoveAt(0);
            }
        }

        protected override void UpdateFieldState(Field Field)
        {
            if(!this.Trapps.Any())
            {
                Field.State = NormalFieldState.GetInstance();
            }
        }

        public override FieldStateMemento CreateMemento()
        {
            FieldStateMemento Memento = base.CreateMemento();
            foreach(Skill Skill in this.Trapps)
            {
                Memento.Skills.Add(Skill.CreateMemento());
            }
            return Memento;
        }

        public override void Restore(FieldStateMemento Memento)
        {
            base.Restore(Memento);

            this.Trapps = Memento.Skills.Select(SkillMemento => SkillMemento.Skill.Restore(SkillMemento)).ToList();
        }

        public override string ToScreenText()
        {
            return "Trapped";
        }
    }
}
