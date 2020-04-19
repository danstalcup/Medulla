using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.Rendering;
using NUnit.Framework;

namespace Medulla.Engine.Tests.Rendering
{
    public class BattleUnitRenderTests
    {
        private BattleUnitRender classUnderTest;

        [SetUp]
        public void SetUp()
        {
            classUnderTest = new BattleUnitRender();
        }

        [TestCase("Nun-Nun")]
        [TestCase("Fiona")]        
        public void RenderHtml_ShowsUnitNameInTd(string name)
        {
            //arrange
            var unit = new BattleUnit {Name = name, HP = 10};

            //act
            var result = classUnderTest.RenderHtml(unit, BattleUnitRender.RenderStyle.Normal);

            //assert
            result.Should().Be($"<td>{name}<br>HP: 10<br>Cooldown: 0<br><br>Attack: 0<br>Speed: 0</td>");
        }

        [TestCase("Nun-Nun")]
        [TestCase("Fiona")]
        public void RenderHtml_ZeroHealth_ShowsEmpty(string name)
        {
            //arrange
            var unit = new BattleUnit { Name = name, HP = 0 };

            //act
            var result = classUnderTest.RenderHtml(unit, BattleUnitRender.RenderStyle.Normal);

            //assert
            result.Should().BeEmpty();
        }

        [TestCase("Nun-Nun")]
        [TestCase("Fiona")]
        public void RenderDetailsHtml_ShowsUnitDetailsInUl(string name)
        {
            //arrange
            var unit = new BattleUnit { Name = name, HP = 1, Speed = 2, Attack = 3, Cooldown = 4};

            //act
            var result = classUnderTest.RenderDetailsHtml(unit);

            //assert
            result.Should().Be($"<ul><li>{name}</li><li>HP: 1</li><li>Cooldown: 4</li><br><li>Attack: 3</li><li>Speed: 2</li></ul>");
        }

        [TestCase("Nun-Nun")]
        [TestCase("Fiona")]
        public void RenderHtml_Current_ShowsUnitNameInTdAndBold(string name)
        {
            //arrange
            var unit = new BattleUnit { Name = name, HP = 10 };

            //act
            var result = classUnderTest.RenderHtml(unit, BattleUnitRender.RenderStyle.Current);

            //assert
            result.Should().Be($"<td><b>{name}<br>HP: 10<br>Cooldown: 0<br><br>Attack: 0<br>Speed: 0</b></td>");
        }

        [TestCase("Nun-Nun")]
        [TestCase("Fiona")]
        public void RenderHtml_Target_ShowsUnitNameInTdAndItalic(string name)
        {
            //arrange
            var unit = new BattleUnit { Name = name, HP = 10 };

            //act
            var result = classUnderTest.RenderHtml(unit, BattleUnitRender.RenderStyle.Target);

            //assert
            result.Should().Be($"<td><i>{name}<br>HP: 10<br>Cooldown: 0<br><br>Attack: 0<br>Speed: 0</i></td>");
        }
    }
}
