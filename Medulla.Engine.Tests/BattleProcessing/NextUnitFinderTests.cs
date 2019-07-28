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
    public class NextUnitFinderTests
    {
        private NextUnitFinder classUnderTest;
        private Battle battle;
        private BattleUnit firstUnit;
        private BattleUnit secondUnit;

        [SetUp]
        public void SetUp()
        {
            battle = new Battle();
            firstUnit = new BattleUnit { Cooldown = 5, HP = 5 };
            secondUnit = new BattleUnit { Cooldown = 10, HP = 5 };
            classUnderTest = new NextUnitFinder();
        }

        [Test]
        public void GetNextBattleUnit_JustOneUnitInTeam1_UnitWithMinCooldownFound()
        {
            //arrange
            battle.Team1.Units.Add(firstUnit);

            //act
            var result = classUnderTest.GetNextBattleUnit(battle);

            //assert
            result.Should().Be(firstUnit);
        }

        [Test]
        public void GetNextBattleUnit_JustOneUnitInTeam2_UnitWithMinCooldownFound()
        {
            //arrange
            battle.Team2.Units.Add(firstUnit);

            //act
            var result = classUnderTest.GetNextBattleUnit(battle);

            //assert
            result.Should().Be(firstUnit);
        }

        [Test]
        public void GetNextBattleUnit_MinInTeam1OtherInTeam2_UnitWithMinCooldownFound()
        {
            //arrange
            battle.Team1.Units.Add(firstUnit);
            battle.Team2.Units.Add(secondUnit);

            //act
            var result = classUnderTest.GetNextBattleUnit(battle);

            //assert
            result.Should().Be(firstUnit);
        }

        [Test]
        public void GetNextBattleUnit_MinInTeam2OtherInTeam1_UnitWithMinCooldownFound()
        {
            //arrange
            battle.Team2.Units.Add(firstUnit);
            battle.Team1.Units.Add(secondUnit);

            //act
            var result = classUnderTest.GetNextBattleUnit(battle);

            //assert
            result.Should().Be(firstUnit);
        }

        [Test]
        public void GetNextBattleUnit_BothInTeam1_UnitWithMinCooldownFound()
        {
            //arrange
            battle.Team1.Units.Add(secondUnit);        
            battle.Team1.Units.Add(firstUnit);

            //act
            var result = classUnderTest.GetNextBattleUnit(battle);

            //assert
            result.Should().Be(firstUnit);
        }

        [Test]
        public void GetNextBattleUnit_BothInTeam2_UnitWithMinCooldownFound()
        {
            //arrange
            battle.Team2.Units.Add(secondUnit);
            battle.Team2.Units.Add(firstUnit);

            //act
            var result = classUnderTest.GetNextBattleUnit(battle);

            //assert
            result.Should().Be(firstUnit);
        }

        [Test]
        public void GetNextBattleUnit_OneUnitHasHP_UnitFoundHasHP()
        {
            //arrange
            battle.Team1.Units.Add(firstUnit);
            battle.Team2.Units.Add(secondUnit);

            firstUnit.HP = 0;

            //act
            var result = classUnderTest.GetNextBattleUnit(battle);

            //assert
            result.Should().Be(secondUnit);
        }

        [Test]
        public void NextUnitIsPlayer_IfTeam1_True()
        {
            //arrange
            battle.Team1.Units.Add(firstUnit);
            battle.Team2.Units.Add(secondUnit);

            //act
            var result = classUnderTest.IsNextUnitPlayerControlled(battle);

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void NextUnitIsPlayer_IfTeam2_False()
        {
            //arrange
            battle.Team2.Units.Add(firstUnit);
            battle.Team1.Units.Add(secondUnit);

            //act
            var result = classUnderTest.IsNextUnitPlayerControlled(battle);

            //assert
            result.Should().BeFalse();
        }
    }
}
