using Medulla.Core.Battles;

namespace Medulla.Engine.BattleProcessing.Implemented
{
    public class CooldownUpdater : ICooldownUpdater
    {
        public void DecrementCooldownsByNextUnitsCooldown(Battle battle, BattleUnit nextUnit)
        {
            var cooldownDecrease = nextUnit.Cooldown;
            foreach (var unit in battle.AllUnits)
            {
                unit.Cooldown -= cooldownDecrease;
            }
        }
    }
}
