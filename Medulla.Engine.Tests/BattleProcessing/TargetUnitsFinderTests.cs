using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.BattleProcessing;
using Moq.AutoMock;
using NUnit.Framework;

namespace Medulla.Engine.Tests.BattleProcessing
{
    public class TargetUnitsFinderTests
    {
        private AutoMocker mocker;
        private TargetUnitsFinder classUnderTest;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMocker();
            classUnderTest = mocker.CreateInstance<TargetUnitsFinder>();
        }

        [Test]
        public void FindTargetUnitNames_ReturnsOpposingTeamsUnitNames()
        {
            //arrange
            var currentUnit = new BattleUnit();
            var opposingTeam = new BattleTeam();
            var battle = new Battle();
            opposingTeam.Units.Add(new BattleUnit { Name = "Nun-Nun", HP = 5 });
            opposingTeam.Units.Add(new BattleUnit { Name = "Fiona", HP = 5 });
            mocker.GetMock<ITeamFinder>().Setup(x => x.FindOpposingTeam(battle, currentUnit)).Returns(opposingTeam);
            
            //act
            var result = classUnderTest.FindTargetUnitNames(battle, currentUnit, string.Empty, string.Empty);

            //assert
            result.Count.Should().Be(2);
            result.Should().Contain("Nun-Nun");
            result.Should().Contain("Fiona");
        }

        [Test]
        public void FindTargetUnitNames_WithSome0HPUnits_ReturnsOpposingTeamsUnitNamesWithPositiveHP()
        {
            //arrange
            var currentUnit = new BattleUnit();
            var opposingTeam = new BattleTeam();
            var battle = new Battle();
            opposingTeam.Units.Add(new BattleUnit { Name = "Nun-Nun", HP = 5 });
            opposingTeam.Units.Add(new BattleUnit { Name = "Fiona", HP = 0 });
            mocker.GetMock<ITeamFinder>().Setup(x => x.FindOpposingTeam(battle, currentUnit)).Returns(opposingTeam);

            //act
            var result = classUnderTest.FindTargetUnitNames(battle, currentUnit, string.Empty, string.Empty);

            //assert
            result.Count.Should().Be(1);
            result.Should().Contain("Nun-Nun");
        }

        [Test]
        public void FindTargetForAI_PullsFirstUnitFromTeam1WithPositiveHp()
        {
            var deadUnit = new BattleUnit();
            var firstUnit = new BattleUnit { HP = 1 };
            var secondUnit = new BattleUnit { HP = 2 };
            var team2Unit = new BattleUnit { HP = 3 };
            var battle = new Battle();
            battle.Team1.Units = new List<BattleUnit> {deadUnit, firstUnit, secondUnit};
            battle.Team2.Units.Add(team2Unit);

            //act
            var result = classUnderTest.FindTargetForAI(battle, new BattleUnit(), string.Empty, string.Empty);

            //assert
            result.Should().Be(firstUnit);
        }
    }
}
