using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.BattleProcessing;
using Medulla.Engine.BattleProcessing.Implemented;
using Moq.AutoMock;
using NUnit.Framework;

namespace Medulla.Engine.Tests.BattleProcessing
{
    public class TeamFinderTests
    {        
        private TeamFinder classUnderTest;

        [SetUp]
        public void SetUp()
        {            
            classUnderTest = new TeamFinder();
        }

        [Test]
        public void FindOpposingTeam_WhenTeam1_IsTeam2()
        {
            //arrange
            var battle = new Battle();
            var battleUnit = new BattleUnit();
            battle.Team1.Units.Add(battleUnit);

            //act
            var result = classUnderTest.FindOpposingTeam(battle, battleUnit);

            //assert
            result.Should().Be(battle.Team2);
        }

        [Test]
        public void FindOpposingTeam_WhenTeam2_IsTeam1()
        {
            //arrange
            var battle = new Battle();
            var battleUnit = new BattleUnit();
            battle.Team2.Units.Add(battleUnit);

            //act
            var result = classUnderTest.FindOpposingTeam(battle, battleUnit);

            //assert
            result.Should().Be(battle.Team1);
        }
    }
}
