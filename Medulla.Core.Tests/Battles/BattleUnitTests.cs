using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using NUnit.Framework;

namespace Medulla.Core.Tests.Battles
{
    public class BattleUnitTests
    {
        [Test]
        public void IsAlive_PositiveHP_True()
        {
            //arrange
            //act
            var result = new BattleUnit {HP = 1}.IsAlive;

            //assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsAlive_ZeroHP_False()
        {
            //arrange
            //act
            var result = new BattleUnit { HP = 0 }.IsAlive;

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsAlive_NegativeHP_False()
        {
            //arrange
            //act
            var result = new BattleUnit { HP = -1 }.IsAlive;

            //assert
            result.Should().BeFalse();
        }
    }
}
