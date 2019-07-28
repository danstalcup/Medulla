using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.Rendering
{
    public class BattleUnitRender : IBattleUnitRender
    {
        public string RenderHtml(BattleUnit battleUnit, RenderStyle renderStyle)
        {
            if (battleUnit.HP <= 0)
            {
                return string.Empty;                
            }
            string decorator = (renderStyle == RenderStyle.Current ? "<b>" : renderStyle == RenderStyle.Target ? "<i>" : string.Empty );
            string decoratorClose = (renderStyle == RenderStyle.Current ? "</b>" : renderStyle == RenderStyle.Target ? "</i>" : string.Empty);
            return $"<td>{decorator}{battleUnit.Name}<br>HP: {battleUnit.HP}<br>Cooldown: {battleUnit.Cooldown}{decoratorClose}</td>";
        }

        public string RenderDetailsHtml(BattleUnit battleUnit)
        {
            return $"<ul><li>{battleUnit.Name}</li><li>HP: {battleUnit.HP}</li></ul>";
        }

        public enum RenderStyle { Normal, Current, Target }
    }
}
