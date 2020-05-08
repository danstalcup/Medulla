using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.Rendering;
using Medulla.Engine.Rendering.Implemented;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Medulla.Engine.Tests.Rendering
{
    public class BattleRenderTests
    {
        private AutoMocker mocker;
        private BattleRender classUnderTest;
        
         
        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMocker();            
            classUnderTest = mocker.CreateInstance<BattleRender>();
        }

        [Test]
        public void RenderHtml_IncludesTwoTeamRenders()
        {
            //arrange
            var currentUnit = new BattleUnit();
            var targetUnit = new BattleUnit();
            mocker.GetMock<IBattleTeamRender>().Setup(x => x.RenderHtml(It.IsAny<BattleTeam>(), currentUnit, targetUnit)).Returns("ABC");

            //act
            var result = classUnderTest.RenderHtml(new Battle(), currentUnit, targetUnit);

            //assert
            result.Should().Be("ABCABC");
        }

        [Test]
        public void RenderBattleOrderHtml_RendersPlayersNamesInOrderWithDashesForTeam2()
        {
            //arrange
            var battle = new Battle();
            battle.Team1.Units.Add(new BattleUnit { Cooldown = 5, Name = "Aa", HP = 1});
            battle.Team2.Units.Add(new BattleUnit { Cooldown = 10, Name = "Bb", HP = 1});

            //act
            var result = classUnderTest.RenderBattleOrderHtml(battle);

            //assert
            result.Should().Be("<table border=\"1\"><tr><td>Aa (5)</td></tr><tr><td>-Bb (10)</td></tr></table>");
        }
    }
}
