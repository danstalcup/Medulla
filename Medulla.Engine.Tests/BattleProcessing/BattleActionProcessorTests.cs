using Medulla.Engine.BattleProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.BattleProcessing.Implemented;
using NUnit.Framework;

namespace Medulla.Engine.Tests.BattleProcessing
{
    public class BattleActionProcessorTests
    {
        private BattleActionProcessor classUnderTest;

        [SetUp]
        public void SetUp()
        {
            classUnderTest = new BattleActionProcessor();
        }

        [Test]
        public void ProcessBattleAction_SubtractsHP()
        {
            //arrange
            var unit1 = new BattleUnit {HP = 100};
            var unit2 = new BattleUnit {Attack = 30};

            //act
            classUnderTest.ProcessBattleAction("Attack", "Basic Attack", unit2, unit1);

            //assert
            unit1.HP.Should().Be(70);
        }

        [Test]
        public void ProcessBattleAction_SetsHPToZeroIfResultIsNegative()
        {
            //arrange
            var unit1 = new BattleUnit { HP = 100 };
            var unit2 = new BattleUnit { Attack = 105 };

            //act
            classUnderTest.ProcessBattleAction("Attack", "Basic Attack", unit2, unit1);

            //assert
            unit1.HP.Should().Be(0);
        }
    }
}
