using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.TestBuilders
{
    class TestBattleTeamBuilder
    {
        private Random random;

        public TestBattleTeamBuilder(Random random)
        {
            this.random = random;
        }
        public BattleTeam Build(string startingLetter, int numUnits = 3)
        {
            var team = new BattleTeam();
            var unitBuilder = new TestBattleUnitBuilder(random);
            for (int i = 0; i < numUnits; i++)
            {
                team.Units.Add(unitBuilder.Build(startingLetter));
            }

            return team;
        }
    }
}
