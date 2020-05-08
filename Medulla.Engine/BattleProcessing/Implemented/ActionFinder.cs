using System.Collections.Generic;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing.Implemented
{
    public class ActionFinder : IActionFinder
    {
        public List<string> FindActionTypes(BattleUnit battleUnit)
        {
            return new List<string>() { "Attack" };
        }

        public List<string> FindActions(BattleUnit battleUnit, string actionType)
        {
            if(string.IsNullOrEmpty(actionType)) { return new List<string>(0); }
            return new List<string>() { "Basic Attack" };
        }
    }
}
