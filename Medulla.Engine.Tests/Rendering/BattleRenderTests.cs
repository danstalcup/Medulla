using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.Rendering;
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
    }
}
