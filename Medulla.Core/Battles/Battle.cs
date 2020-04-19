using System.Collections.Generic;
using System.Linq;

namespace Medulla.Core.Battles
{
    public class Battle
    {     
        public BattleTeam Team1 { get; set; } = new BattleTeam();
        public BattleTeam Team2 { get; set; } = new BattleTeam();
        public BattleResult Result { get; set; } = new BattleResult();

        public IEnumerable<BattleUnit> AllUnits => Team1.Units.Union(Team2.Units);

        public bool IsBattleOver => !Team1.IsAlive || !Team2.IsAlive;

        public bool DidYouWin => Team1.IsAlive && !Team2.IsAlive;
    }
}
