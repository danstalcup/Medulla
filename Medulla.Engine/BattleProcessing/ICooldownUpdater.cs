using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public interface ICooldownUpdater
    {
        void DecrementCooldownsByNextUnitsCooldown(Battle battle, BattleUnit nextUnit);
    }
}
