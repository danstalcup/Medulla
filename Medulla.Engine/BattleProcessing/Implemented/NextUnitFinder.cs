using System.Linq;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing.Implemented
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
