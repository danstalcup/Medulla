using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
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
