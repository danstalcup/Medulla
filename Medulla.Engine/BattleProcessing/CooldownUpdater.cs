using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing
{
    public class CooldownUpdater : ICooldownUpdater
    {
        public void DecrementCooldownsByNextUnitsCooldown(Battle battle, BattleUnit nextUnit)
        {
            var cooldownDecrease = nextUnit.Cooldown;
            foreach (var unit in battle.Team1.Units.Union(battle.Team2.Units))
            {
                unit.Cooldown -= cooldownDecrease;
            }
        }
    }
}
