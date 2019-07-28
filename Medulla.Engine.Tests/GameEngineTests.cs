﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Medulla.Core.Battles;
using Medulla.Engine.BattleProcessing;
using Medulla.Engine.Rendering;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Medulla.Engine.Tests
{
    public class GameEngineTests
    {
        private GameEngine classUnderTest;
        private AutoMocker mocker;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMocker();
            classUnderTest = mocker.CreateInstance<GameEngine>();
        }

        [Test]
        public void GetBattleRenderHtml_CallsBattleRenderAndUnitDetails()
        {
            //arrange
            var nextUnit = new BattleUnit();
            var target = new BattleUnit{Name = "Target"};
            mocker.GetMock<IBattleRender>().Setup(x => x.RenderHtml(It.IsAny<Battle>(), It.IsAny<BattleUnit>(), It.IsAny<BattleUnit>())).Returns("Howdy");
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(nextUnit);
            mocker.GetMock<IBattleUnitRender>().Setup(x => x.RenderDetailsHtml(nextUnit)).Returns("Apple");
            mocker.GetMock<IBattleUnitRender>().Setup(x => x.RenderDetailsHtml(target)).Returns("Banana");
            classUnderTest.CurrentBattle.Team1.Units.Add(target);
            classUnderTest.StartBattle();
            classUnderTest.SetSelectedBattleActionTarget("Target");

            //act
            var result = classUnderTest.GetBattleRenderHtml();

            //assert
            result.Should().Be("Howdy<h2>Current Unit:</h2>Apple<h2>Action:</h2><p></p><h2>Target:</h2>Banana");
        }

        [Test]
        public void GetBattleActionTypes_CallsActionFinderForNextUnit()
        {
            //arrange
            var nextUnit = new BattleUnit {Name = "Testerly"};
            var actionTypes = new List<string> {"Test Action"};
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(nextUnit);
            mocker.GetMock<IActionFinder>().Setup(x => x.FindActionTypes(nextUnit)).Returns(actionTypes);
            classUnderTest.StartBattle();

            //act
            var result = classUnderTest.GetBattleActionTypes();

            //assert
            result.Should().BeEquivalentTo(actionTypes);
        }

        [Test]
        public void GetBattleActions_CallsActionFinderForNextUnit()
        {
            //arrange
            var nextUnit = new BattleUnit { Name = "Testerly" };
            var actions = new List<string> { "Test Action" };
            classUnderTest.SetSelectedBattleActionType("Test Type");
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(nextUnit);
            classUnderTest.StartBattle();
            mocker.GetMock<IActionFinder>().Setup(x => x.FindActions(nextUnit, "Test Type")).Returns(actions);            

            //act
            var result = classUnderTest.GetBattleActions();

            //assert
            result.Should().BeEquivalentTo(actions);
        }

        [Test]
        public void SetSelectedBattleActionType_SetsTypeToProperty()
        {
            //act
            classUnderTest.SetSelectedBattleActionType("Test Type");

            //assert
            classUnderTest.SelectedBattleActionType.Should().Be("Test Type");
        }

        [Test]
        public void SetSelectedBattleAction_SetsActionToProperty()
        {
            //act
            classUnderTest.SetSelectedBattleAction("Test Action");

            //assert
            classUnderTest.SelectedBattleAction.Should().Be("Test Action");
        }

        [Test]
        public void GetBattleTargets_ReturnsPossibleTargetsFromFinder()
        {
            //arrange
            var nextUnit = new BattleUnit { Name = "Testerly" };
            var targetNames = new List<string> { "Test Name" };
            classUnderTest.SetSelectedBattleActionType("Test Type");
            classUnderTest.SetSelectedBattleAction("Test Action");
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(nextUnit);
            classUnderTest.StartBattle();
            mocker.GetMock<ITargetUnitsFinder>().Setup(x => x.FindTargetUnitNames(It.IsAny<Battle>(), nextUnit, "Test Type", "Test Action")).Returns(targetNames);

            //act
            var result = classUnderTest.GetBattleTargets();

            //assert
            result.Should().BeEquivalentTo(targetNames);

        }

        [Test]
        public void StartBattle_CallsCooldownUpdater()
        {
            //arrange
            var nextUnit = new BattleUnit { Name = "Testerly" };
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(nextUnit);

            //act
            classUnderTest.StartBattle();

            //assert

            mocker.GetMock<ICooldownUpdater>().Verify(x => x.DecrementCooldownsByNextUnitsCooldown(It.IsAny<Battle>(), nextUnit), Times.Once);
        }

        [Test]
        public void StartBattle_CallsNextUnitFinder()
        {
            //arrange

            //act
            classUnderTest.StartBattle();

            //assert

            mocker.GetMock<INextUnitFinder>().Verify(x => x.GetNextBattleUnit(It.IsAny<Battle>()), Times.Once);
        }

        [Test]
        public void ProcessBattleAction_CallsCooldownUpdater()
        {
            //arrange
            var nextUnit = new BattleUnit { Name = "Testerly" };
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(nextUnit);
            classUnderTest.StartBattle();

            //act
            classUnderTest.ProcessBattleAction();

            //assert
            //twice because StartBattle is used for setup
            mocker.GetMock<ICooldownUpdater>().Verify(x => x.DecrementCooldownsByNextUnitsCooldown(It.IsAny<Battle>(), nextUnit), Times.Exactly(2));
        }

        [Test]
        public void ProcessBattleAction_CallsProcessAction()
        {
            //arrange
            var target = new BattleUnit{Name = "Target"};
            classUnderTest.CurrentBattle.Team1.Units.Add(target);
            classUnderTest.SetSelectedBattleActionTarget("Target");
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(new BattleUnit());
            classUnderTest.StartBattle();

            //act
            classUnderTest.ProcessBattleAction();

            //assert
            mocker.GetMock<IBattleActionProcessor>().Verify(x => x.ProcessBattleAction(It.IsAny<string>(), It.IsAny<string>(), target), Times.Once);
        }

        [Test]
        public void ProcessBattleAction_CallsGetNextBattleUnit()
        {
            //arrange
            mocker.GetMock<INextUnitFinder>().Setup(x => x.GetNextBattleUnit(It.IsAny<Battle>())).Returns(new BattleUnit());
            classUnderTest.StartBattle();

            //act
            classUnderTest.ProcessBattleAction();

            //assert
            //twice because StartBattle is used for setup
            mocker.GetMock<INextUnitFinder>().Verify(x => x.GetNextBattleUnit(It.IsAny<Battle>()), Times.Exactly(2));
        }
    }
}
