using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public interface IActionFinder
    {
        List<string> FindActionTypes(BattleUnit battleUnit);

        List<string> FindActions(BattleUnit battleUnit, string actionType);
    }
}
