using System.Linq;
using System.Text;
using Medulla.Core.Battles;

namespace Medulla.Engine.Rendering.Implemented
{
    public class BattleRender : IBattleRender
    {
        private readonly IBattleTeamRender battleTeamRender;

        public BattleRender(IBattleTeamRender battleTeamRender)
        {
            this.battleTeamRender = battleTeamRender;
        }

        public string RenderHtml(Battle battle, BattleUnit currentUnit, BattleUnit targetUnit)
        {
            var renderHtml = new StringBuilder();
            renderHtml.Append(battleTeamRender.RenderHtml(battle.Team1, currentUnit, targetUnit));
            renderHtml.Append(battleTeamRender.RenderHtml(battle.Team2, currentUnit, targetUnit));
            return renderHtml.ToString();
        }

        public string RenderBattleOrderHtml(Battle battle)
        {
            var renderHtml = new StringBuilder("<table border=\"1\">");
            var battleOrder = battle.AllUnits.Where(x => x.IsAlive).OrderBy(x => x.Cooldown).ToList();
            foreach (var unit in battleOrder)
            {
                renderHtml.Append("<tr><td>");
                var isUnitPlayer = battle.Team1.Units.Contains(unit);
                renderHtml.Append(isUnitPlayer ? string.Empty : "-");
                renderHtml.Append(unit.Name);
                renderHtml.Append($" ({unit.Cooldown})");
                renderHtml.Append("</td></tr>");
            }

            renderHtml.Append("</table>");
            return renderHtml.ToString();
        }
    }
}
