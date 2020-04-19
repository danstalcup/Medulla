using System.Linq;
using FluentAssertions;
using Medulla.Core.Battles;
using NUnit.Framework;

namespace Medulla.Core.Tests.Battles
{
    public class BattleTests
    {
        [Test]
        public void AllUnits_PullsFromBothBattleTeams()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit();
            var unit2 = new BattleUnit();
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.AllUnits.ToList();

            //assert
            result.Count().Should().Be(2);
            result.Should().Contain(unit1);
            result.Should().Contain(unit2);
        }

        [Test]
        public void IsBattleOver_Team1AndTeam2UnitsAlive_False()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit {HP = 5};
            var unit2 = new BattleUnit {HP = 5};
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.IsBattleOver;

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsBattleOver_JustTeam1UnitsAlive_True()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { HP = 5 };
            var unit2 = new BattleUnit { HP = 0 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.IsBattleOver;

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsBattleOver_JustTeam2UnitsAlive_True()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { HP = 0 };
            var unit2 = new BattleUnit { HP = 5 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.IsBattleOver;

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsBattleOver_NeitherTeamAlive_True()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { HP = 0 };
            var unit2 = new BattleUnit { HP = 0 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.IsBattleOver;

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void DidYouWin_Team1AndTeam2UnitsAlive_False()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { HP = 5 };
            var unit2 = new BattleUnit { HP = 5 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.DidYouWin;

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void DidYouWin_JustTeam1UnitsAlive_True()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { HP = 5 };
            var unit2 = new BattleUnit { HP = 0 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.DidYouWin;

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void DidYouWin_JustTeam2UnitsAlive_False()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { HP = 0 };
            var unit2 = new BattleUnit { HP = 5 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.DidYouWin;

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void DidYouWin_NeitherTeamAlive_False()
        {
            //arrange
            var battle = new Battle();
            var unit1 = new BattleUnit { HP = 0 };
            var unit2 = new BattleUnit { HP = 0 };
            battle.Team1.Units.Add(unit1);
            battle.Team2.Units.Add(unit2);

            //act
            var result = battle.DidYouWin;

            //assert
            result.Should().BeFalse();
        }
    }
}
