using Medulla.Core.Battles;

namespace Medulla.Engine.Rendering.Implemented
{
    public class BattleUnitRender : IBattleUnitRender
    {
        public string RenderHtml(BattleUnit battleUnit, RenderStyle renderStyle)
        {
            if (!battleUnit.IsAlive )
            {
                return string.Empty;                
            }
            string decorator = (renderStyle == RenderStyle.Current ? "<b>" : renderStyle == RenderStyle.Target ? "<i>" : string.Empty );
            string decoratorClose = (renderStyle == RenderStyle.Current ? "</b>" : renderStyle == RenderStyle.Target ? "</i>" : string.Empty);
            return $"<td>{decorator}{battleUnit.Name}<br>HP: {battleUnit.HP}<br>Cooldown: {battleUnit.Cooldown}<br><br>Attack: {battleUnit.Attack}<br>Speed: {battleUnit.Speed}{decoratorClose}</td>";
        }

        public string RenderDetailsHtml(BattleUnit battleUnit)
        {
            return $"<ul><li>{battleUnit.Name}</li><li>HP: {battleUnit.HP}</li><li>Cooldown: {battleUnit.Cooldown}</li><br><li>Attack: {battleUnit.Attack}</li><li>Speed: {battleUnit.Speed}</li></ul>";
        }

        public enum RenderStyle { Normal, Current, Target }
    }
}
