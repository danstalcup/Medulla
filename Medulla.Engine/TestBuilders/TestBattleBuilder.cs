using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.TestBuilders
{
    public class TestBattleBuilder
    {
        public Battle Build()
        {
            var random = new Random();
            var battle = new Battle();
            var teamBuilder = new TestBattleTeamBuilder(random);
            battle.Team1 = teamBuilder.Build("A");
            battle.Team2 = teamBuilder.Build("B");
            battle.Result.ExperienceGained = battle.Team2.Units.Sum(x => x.MaxHP);
            return battle;
        }
    }
}
