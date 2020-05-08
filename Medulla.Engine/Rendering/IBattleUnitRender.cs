using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;
using Medulla.Engine.Rendering.Implemented;

namespace Medulla.Engine.Rendering
{
    public interface IBattleUnitRender
    {
        string RenderHtml(BattleUnit battleUnit, BattleUnitRender.RenderStyle renderStyle);
        string RenderDetailsHtml(BattleUnit battleUnit);
    }
}
