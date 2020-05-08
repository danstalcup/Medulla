using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing.Implemented
{
    public class BattleEndingProcessor : IBattleEndingProcessor
    {
        public void ProcessBattleEnding(Battle battle)
        {
            if (battle.DidYouWin)
            {
                foreach (var unit in battle.Team1.Units)
                {
                    if (unit.Character != null)
                    {
                        unit.Character.ExperienceAvailable += battle.Result.ExperienceGained;
                        unit.Character.ExperienceTotal += battle.Result.ExperienceGained;
                    }

                }
            }
        }
    }
}
