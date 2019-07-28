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
            return battle.Team1.Units.Union(battle.Team2.Units).OrderBy(x => x.Cooldown).First(x => x.HP > 0);
        }

        public bool IsNextUnitPlayerControlled(Battle battle)
        {
            var nextUnit = GetNextBattleUnit(battle);
            return battle.Team1.Units.Contains(nextUnit);
        }
    }
}
