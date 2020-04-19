using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Battles;

namespace Medulla.Engine.TestBuilders
{
    public class TestBattleUnitBuilder
    {
        private readonly Random random;

        public TestBattleUnitBuilder(Random random)
        {
            this.random = random;
        }
        public BattleUnit Build(string startingLetter)
        {
            var unit = new BattleUnit();            
            unit.Name = startingLetter + RandomString(5);
            unit.Cooldown = random.Next(100);
            unit.HP = random.Next(20);
            unit.Speed = random.Next(15) + 1;
            unit.Attack = random.Next(10) + 1;
            return unit;
        }

        private string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
