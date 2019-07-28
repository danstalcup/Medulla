using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.BattleProcessing;
using NUnit.Framework;

namespace Medulla.Engine.Tests.BattleProcessing
{
    public class CooldownUpdaterTests
    {
        private CooldownUpdater classUnderTest;

        [SetUp]
        public void SetUp()
        {
            classUnderTest = new CooldownUpdater();
        }

        [Test]
        public void DecrementCooldownsByNextUnitsCooldown_DecrementsCooldownsOfUnitsOnBothTeams()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { Cooldown = 5 };
            var unit2 = new BattleUnit { Cooldown = 6 };
            var unit3 = new BattleUnit { Cooldown = 10 };
            var unit4 = new BattleUnit { Cooldown = 100 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);
            battle.Team1.Units.Add(unit3);
            battle.Team1.Units.Add(unit4);

            //act
            classUnderTest.DecrementCooldownsByNextUnitsCooldown(battle, unit1);

            //assert
            unit1.Cooldown.Should().Be(0);
            unit2.Cooldown.Should().Be(1);
            unit3.Cooldown.Should().Be(5);
            unit4.Cooldown.Should().Be(95);
        }
    }
}
