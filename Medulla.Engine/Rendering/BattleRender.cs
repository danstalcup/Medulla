using System.Text;
using Medulla.Core.Battles;

namespace Medulla.Engine.Rendering
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
    }
}
