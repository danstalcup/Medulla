using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.Rendering
{
    public interface IBattleRender
    {
        string RenderHtml(Battle battle, BattleUnit currentUnit, BattleUnit targetUnit);
    }
}
