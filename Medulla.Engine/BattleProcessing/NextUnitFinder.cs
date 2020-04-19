using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public class NextUnitFinder : INextUnitFinder
    {
        public BattleUnit GetNextBattleUnit(Battle battle)
        {
            return battle.AllUnits.OrderBy(x => x.Cooldown).First(x => x.IsAlive );
        }

        public bool IsNextUnitPlayerControlled(Battle battle)
        {
            var nextUnit = GetNextBattleUnit(battle);
            return battle.Team1.Units.Contains(nextUnit);
        }
    }
}
