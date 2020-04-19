using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public class BattleActionProcessor : IBattleActionProcessor
    {
        public void ProcessBattleAction(string actionType, string action, BattleUnit currentUnit, BattleUnit targetUnit)
        {
            targetUnit.HP -= currentUnit.Attack;
            if (targetUnit.HP < 0)
            {
                targetUnit.HP = 0;                
            }
            
        }
    }
}
