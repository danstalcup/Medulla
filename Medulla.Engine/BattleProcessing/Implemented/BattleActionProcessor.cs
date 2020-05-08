using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing.Implemented
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
