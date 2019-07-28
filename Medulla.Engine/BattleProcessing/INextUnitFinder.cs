using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public interface INextUnitFinder
    {
        BattleUnit GetNextBattleUnit(Battle battle);

        bool IsNextUnitPlayerControlled(Battle battle);
    }
}
