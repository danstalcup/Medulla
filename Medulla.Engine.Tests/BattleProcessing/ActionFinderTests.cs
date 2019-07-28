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
    public class ActionFinderTests
    {
        private ActionFinder classUnderTest;

        [SetUp]
        public void SetUp()
        {
            classUnderTest = new ActionFinder();
        }

        [Test]
        public void FindActionTypes_ReturnsAttack()
        {
            //act
            var result = classUnderTest.FindActionTypes(new BattleUnit());

            //assert
            result.Should().Contain("Attack");
            result.Count.Should().Be(1);
        }

        [Test]
        public void FindActions_Null_ReturnsEmptyList()
        {
            //act
            var result = classUnderTest.FindActions(new BattleUnit(), null);

            //assert
            result.Count.Should().Be(0);
        }

        [Test]
        public void FindActions_EmptyString_ReturnsEmptyList()
        {
            //act
            var result = classUnderTest.FindActions(new BattleUnit(), string.Empty);

            //assert
            result.Count.Should().Be(0);
        }
    }
}
