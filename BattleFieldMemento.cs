using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
    class BattlefieldMemento
    {
        public List<List<FieldMemento>> BattleGrid { get; }
        public List<HeroMemento> Heroes { get; }
        public BattlefieldMemento()
        {
            this.BattleGrid = new List<List<FieldMemento>>();
            this.Heroes = new List<HeroMemento>();
        }
    }
}
