using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public class TargetUnitsFinder : ITargetUnitsFinder
    {
        private readonly ITeamFinder teamFinder;

        public TargetUnitsFinder(ITeamFinder teamFinder)
        {
            this.teamFinder = teamFinder;
        }

        public List<string> FindTargetUnitNames(Battle battle, BattleUnit currentUnit, string actionType, string action)
        {
            return teamFinder.FindOpposingTeam(battle, currentUnit).Units.Where(x => x.HP > 0).Select(x => x.Name).ToList();
        }

        public BattleUnit FindTargetForAI(Battle battle, BattleUnit currentUnit, string actionType, string action)
        {
            return battle.Team1.Units.FirstOrDefault(x => x.IsAlive);
        }
    }
}
