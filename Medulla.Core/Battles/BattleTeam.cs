using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medulla.Core.Battles
{
    public class BattleTeam
    {
        public List<BattleUnit> Units { get; set; } = new List<BattleUnit>();

        public bool IsAlive => Units.Any(x => x.IsAlive);
    }
}
