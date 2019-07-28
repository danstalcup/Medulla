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
        public void ProcessBattleAction(string actionType, string action, BattleUnit target)
        {
            var random = new Random();
            target.HP -= random.Next(5);
            if (target.HP < 0)
            {
                target.HP = 0;
            }
            
        }
    }
}
