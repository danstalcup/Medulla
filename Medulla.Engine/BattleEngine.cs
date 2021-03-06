﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;
using Medulla.Engine.BattleProcessing;
using Medulla.Engine.Rendering;
using Medulla.Engine.TestBuilders;

namespace Medulla.Engine
{
    public class BattleEngine
    {        
        public Battle CurrentBattle { get; set; }

        public string SelectedBattleActionType { get; private set; }      
        
        public string SelectedBattleAction { get; private set; }

        public BattleUnit SelectedBattleActionTarget { get; private set; }

        public BattleUnit NextUnit { get; private set; }

        public bool IsPlayerTurn { get; private set; }

        private readonly IBattleRender battleRender;
        private readonly IActionFinder actionFinder;
        private readonly INextUnitFinder nextUnitFinder;
        private readonly ITargetUnitsFinder targetUnitsFinder;
        private readonly IBattleUnitRender battleUnitRender;
        private readonly ICooldownUpdater cooldownUpdater;
        private readonly IBattleActionProcessor battleActionProcessor;

        public BattleEngine(IBattleRender battleRender, IActionFinder actionFinder, INextUnitFinder nextUnitFinder, ITargetUnitsFinder targetUnitsFinder, IBattleUnitRender battleUnitRender, ICooldownUpdater cooldownUpdater, IBattleActionProcessor battleActionProcessor)
        {
            this.battleRender = battleRender;
            this.actionFinder = actionFinder;
            this.nextUnitFinder = nextUnitFinder;
            this.targetUnitsFinder = targetUnitsFinder;
            this.battleUnitRender = battleUnitRender;
            this.cooldownUpdater = cooldownUpdater;
            this.battleActionProcessor = battleActionProcessor;

            var testBattleBuilder = new TestBattleBuilder();
            CurrentBattle = testBattleBuilder.Build();
        }

        public string GetBattleRenderHtml()
        {
            var result = new StringBuilder();
            result.Append(battleRender.RenderHtml(CurrentBattle, NextUnit, SelectedBattleActionTarget) +
                   $"<h2>Current Unit:</h2>{battleUnitRender.RenderDetailsHtml(NextUnit)}" +
                   $"<h2>Action:</h2><p>{SelectedBattleAction}</p>");
            if (SelectedBattleActionTarget != null)
            {
                result.Append( $"<h2>Target:</h2>{battleUnitRender.RenderDetailsHtml(SelectedBattleActionTarget)}");
            }

            result.Append("<h2>Battle Order:</h2>");
            result.Append(battleRender.RenderBattleOrderHtml(CurrentBattle)); 

            return result.ToString();
        }

        public List<string> GetBattleActionTypes()
        {
            return actionFinder.FindActionTypes(NextUnit);
        }

        public List<string> GetBattleActions()
        {
            return actionFinder.FindActions(NextUnit, SelectedBattleActionType);
        }

        public void SetSelectedBattleActionType(string actionType)
        {
            SelectedBattleActionType = actionType;
        }

        public void SetSelectedBattleAction(string action)
        {
            SelectedBattleAction = action;
        }

        public void SetSelectedBattleActionTarget(string name)
        {
            SelectedBattleActionTarget =
                CurrentBattle.AllUnits.Single(x => x.Name == name);
        }

        public List<string> GetBattleTargets()
        {
            return targetUnitsFinder.FindTargetUnitNames(CurrentBattle, NextUnit, SelectedBattleActionType, SelectedBattleAction);
        }

        public void ProcessBattleAction()
        {
            battleActionProcessor.ProcessBattleAction(SelectedBattleActionType, SelectedBattleAction, NextUnit, SelectedBattleActionTarget);
            var speed = NextUnit.Speed == 0 ? 1 : NextUnit.Speed;
            NextUnit.Cooldown += (int)(100.0 / speed);
            ProcessNextBattleUnit();
            if (IsBattleOver())
            {
                if (DidYouWin())
                {

                }
            }
        }

        public void StartBattle()
        {
            ProcessNextBattleUnit();
        }

        private void ProcessNextBattleUnit()
        {
            NextUnit = nextUnitFinder.GetNextBattleUnit(CurrentBattle);
            IsPlayerTurn = nextUnitFinder.IsNextUnitPlayerControlled(CurrentBattle);
            cooldownUpdater.DecrementCooldownsByNextUnitsCooldown(CurrentBattle, NextUnit);

            if (!IsPlayerTurn)
            {
                ProcessComputerPlayerTarget();
            }
        }

        private void ProcessComputerPlayerTarget()
        {
            SelectedBattleAction = "Basic Attack";
            SelectedBattleActionType = "Attack";
            SelectedBattleActionTarget = targetUnitsFinder.FindTargetForAI(CurrentBattle, NextUnit, SelectedBattleActionType, SelectedBattleAction);
        }

        public bool IsBattleOver()
        {
            return (CurrentBattle ?? new Battle()).IsBattleOver;
        }

        public bool DidYouWin()
        {
            return (CurrentBattle ?? new Battle()).DidYouWin;
        }

        
    }
}
