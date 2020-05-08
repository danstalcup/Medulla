using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.Rendering;
using Medulla.Engine.Rendering.Implemented;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Medulla.Engine.Tests.Rendering
{
    public class BattleTeamRenderTests
    {
        private AutoMocker mocker;
        private BattleTeamRender classUnderTest;        

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMocker();            
            classUnderTest = mocker.CreateInstance<BattleTeamRender>();
        }

        [Test]
        public void RenderHtml_EmptyTeam_ReturnsEmptyTable()

        {
            // act
            var result = classUnderTest.RenderHtml(new BattleTeam(), new BattleUnit(), new BattleUnit());
                
            //assert                
            result.Should().Be("<table border=\"1\"><tr><th>BattleTeam</th></tr><tr></tr></table>");
        }

        [Test]
        public void RenderHtml_Members_CallsWithExpectedRenderStyles()

        {
            //arrange
            var team = new BattleTeam();
            var normal = new BattleUnit();
            var target = new BattleUnit();
            var current = new BattleUnit();
            team.Units.AddRange(new []{
                normal, current, target
            });

            // act
            var result = classUnderTest.RenderHtml(team, current, target);

            //assert                
            mocker.GetMock<IBattleUnitRender>().Verify(x => x.RenderHtml(normal, BattleUnitRender.RenderStyle.Normal), Times.Once);
            mocker.GetMock<IBattleUnitRender>().Verify(x => x.RenderHtml(current, BattleUnitRender.RenderStyle.Current), Times.Once);
            mocker.GetMock<IBattleUnitRender>().Verify(x => x.RenderHtml(target, BattleUnitRender.RenderStyle.Target), Times.Once);

        }
    }
}
