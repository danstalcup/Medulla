using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Characters;

namespace Medulla.Core.Battles
{
    public class BattleUnit
    {
        public BattleUnit() { }

        public BattleUnit(Character character)
        {
            this.Name = character.Name;
            this.HP = character.MaxHP;
            this.MaxHP = character.MaxHP;
            this.Attack = character.Attack;
            this.Speed = character.Speed;
            this.Character = character;
        }

        public string Name { get; set; }

        public int Cooldown { get; set; }

        public int HP { get; set; }

        public int MaxHP { get; set; }

        public int Attack { get; set; }

        public int Speed { get; set; }

        public bool IsAlive => HP > 0;

        public Character Character { get; set; }
    }
}
