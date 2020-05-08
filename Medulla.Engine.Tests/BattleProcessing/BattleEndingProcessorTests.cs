using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Core.Characters;
using Medulla.Engine.BattleProcessing;
using Medulla.Engine.BattleProcessing.Implemented;
using NUnit.Framework;

namespace Medulla.Engine.Tests.BattleProcessing
{
    [TestFixture]
    public class BattleEndingProcessorTests
    {
        private BattleEndingProcessor classUnderTest;

        [SetUp]
        public void Setup()
        {
            classUnderTest = new BattleEndingProcessor();
        }

        [Test]
        public void ProcessBattleEnding_PlayerWon_ExperienceAdded()
        {
            //arrange
            var character1 = new Character();
            var character2 = new Character {ExperienceTotal = 20};
            var battle = new Battle
            {
                Result = new BattleResult {ExperienceGained = 5},
                Team1 = new BattleTeam
                {
                    Units = new List<BattleUnit>
                    {
                        new BattleUnit {HP = 1, Character = character1},
                        new BattleUnit {HP = 2, Character = character2},
                        new BattleUnit()
                    }
                }
            };

            //act
            classUnderTest.ProcessBattleEnding(battle);

            //assert
            character1.ExperienceAvailable.Should().Be(5);
            character1.ExperienceTotal.Should().Be(5);
            character2.ExperienceAvailable.Should().Be(5);
            character2.ExperienceTotal.Should().Be(25);
        }

        [Test]
        public void ProcessBattleEnding_PlayerLost_ExperienceAddedIfPlayerLost()
        {
            //arrange
            var character1 = new Character();
            var character2 = new Character { ExperienceTotal = 20 };
            var battle = new Battle
            {
                Result = new BattleResult { ExperienceGained = 5 },
                Team1 = new BattleTeam
                {
                    Units = new List<BattleUnit>
                    {
                        new BattleUnit {HP = 0, Character = character1},
                        new BattleUnit {HP = 0, Character = character2},
                        new BattleUnit()
                    }
                }
            };

            //act
            classUnderTest.ProcessBattleEnding(battle);

            //assert
            character1.ExperienceAvailable.Should().Be(0);
            character1.ExperienceTotal.Should().Be(0);
            character2.ExperienceAvailable.Should().Be(0);
            character2.ExperienceTotal.Should().Be(20);
        }
    }
}
