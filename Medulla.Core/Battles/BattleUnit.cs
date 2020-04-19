using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medulla.Core.Battles
{
    public class BattleUnit
    {
        public string Name { get; set; }

        public int Cooldown { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Speed { get; set; }

        public bool IsAlive => HP > 0;
    }
}
