using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medulla.Core.Characters
{
    public class Character
    {
        public string Name { get; set; }

        public int MaxHP { get; set; }

        public int Attack { get; set; }

        public int Speed { get; set; }

        public int ExperienceTotal { get; set; }

        public int ExperienceAvailable { get; set; }
    }
}
