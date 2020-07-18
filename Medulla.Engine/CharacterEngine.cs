using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medulla.Core.Characters;

namespace Medulla.Engine
{
    public class CharacterEngine
    {
        private readonly List<Character> characters = new List<Character>();
        public List<Character> GetCharacters()
        {
            return characters;
        }

        public void AddCharacter(string name, int hp, int exp, int attack, int speed)
        {
            var character = new Character
            {
                Name = name,
                Attack = attack,
                Speed = speed,
                MaxHP = hp,
                ExperienceAvailable = exp,
                ExperienceTotal = exp                
            };
            characters.Add(character);
        }

        public void AddCharacter(Character character)
        {
            characters.Add(character);
        }
    }
}
