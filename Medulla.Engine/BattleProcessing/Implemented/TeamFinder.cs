using System.Collections.Generic;
using System.Linq;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing.Implemented
{
    public class TeamFinder : ITeamFinder
    {
        public BattleTeam FindOpposingTeam(Battle battle, BattleUnit battleUnit)
        {
            return GetTeams(battle).Single(x => !x.Units.Contains(battleUnit));
        }

        private IEnumerable<BattleTeam> GetTeams(Battle battle)
        {
            return new[]{ battle.Team1, battle.Team2 };
        }
    }
}
