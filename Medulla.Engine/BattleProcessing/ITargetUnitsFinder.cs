using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public interface ITargetUnitsFinder
    {
        List<string> FindTargetUnitNames(Battle battle, BattleUnit currentUnit, string actionType, string action);

        BattleUnit FindTargetForAI(Battle battle, BattleUnit battleUnit, string actionType, string action);
    }
}
