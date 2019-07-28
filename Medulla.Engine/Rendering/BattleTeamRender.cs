using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.Rendering
{
    public class BattleTeamRender : IBattleTeamRender
    {
        private readonly IBattleUnitRender battleUnitRender;

        public BattleTeamRender(IBattleUnitRender battleUnitRender)
        {
            this.battleUnitRender = battleUnitRender;
        }

        public string RenderHtml(BattleTeam battleTeam, BattleUnit currentUnit, BattleUnit targetUnit)
        {
            var renderHtml = new StringBuilder("<table border=\"1\"><tr><th>BattleTeam</th></tr><tr>");
            foreach (var unit in battleTeam.Units)
            {
                var renderStyle = unit == targetUnit ? BattleUnitRender.RenderStyle.Target :
                    unit == currentUnit ? BattleUnitRender.RenderStyle.Current : BattleUnitRender.RenderStyle.Normal;
                renderHtml.Append(battleUnitRender.RenderHtml(unit, renderStyle));
            }

            renderHtml.Append("</tr></table>");
            return renderHtml.ToString();
        }
    }
}
