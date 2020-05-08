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
            //unit.Name = startingLetter + RandomString(5);
            unit.Name = RandomName();
            unit.Cooldown = random.Next(40);
            unit.HP = random.Next(20);
            unit.MaxHP = unit.HP;
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

        private string RandomName()
        {

            return names[random.Next(names.Length)];
        }

        private static string[] names =
        {
            "Abrielle",
            "Adair",
            "Adara",
            "Adriel",
            "Aiyana",
            "Alissa",
            "Alixandra",
            "Altair",
            "Amara",
            "Anatola",
            "Anya",
            "Arcadia",
            "Ariadne",
            "Arianwen",
            "Aurelia",
            "Aurelian",
            "Aurelius",
            "Avalon",
            "Acalia",
            "Alaire",
            "Auristela",
            "Bastian",
            "Breena",
            "Brielle",
            "Briallan",
            "Briseis",
            "Cambria",
            "Cara",
            "Carys",
            "Caspian",
            "Cassia",
            "Cassiel",
            "Cassiopeia",
            "Cassius",
            "Chaniel",
            "Cora",
            "Corbin",
            "Cyprian",
            "Daire",
            "Darius",
            "Destin",
            "Drake",
            "Drystan",
            "Dagen",
            "Devlin",
            "Devlyn",
            "Eira",
            "Eirian",
            "Elysia",
            "Eoin",
            "Evadne",
            "Eliron",
            "Evanth",
            "Fineas",
            "Finian",
            "Fyodor",
            "Gareth",
            "Gavriel",
            "Griffin",
            "Guinevere",
            "Gaerwn",
            "Ginerva",
            "Hadriel",
            "Hannelore",
            "Hermione",
            "Hesperos",
            "Iagan",
            "Ianthe",
            "Ignacia",
            "Ignatius",
            "Iseult",
            "Isolde",
            "Jessalyn",
            "Kara",
            "Kerensa",
            "Korbin",
            "Kyler",
            "Kyra",
            "Katriel",
            "Kyrielle",
            "Leala",
            "Leila",
            "Lilith",
            "Liora",
            "Lucien",
            "Lyra",
            "Leira",
            "Liriene",
            "Liron",
            "Maia",
            "Marius",
            "Mathieu",
            "Mireille",
            "Mireya",
            "Maylea",
            "Meira",
            "Natania",
            "Nerys",
            "Nuriel",
            "Nyssa",
            "Neirin",
            "Nyfain",
            "Oisin",
            "Oralie",
            "Orion",
            "Orpheus",
            "Ozara",
            "Oleisa",
            "Orinthea",
            "Peregrine",
            "Persephone",
            "Perseus",
            "Petronela",
            "Phelan",
            "Pryderi",
            "Pyralia",
            "Pyralis",
            "Qadira",
            "Quintessa",
            "Quinevere",
            "Raisa",
            "Remus",
            "Rhyan",
            "Rhydderch",
            "Riona",
            "Renfrew",
            "Saoirse",
            "Sarai",
            "Sebastian",
            "Seraphim",
            "Seraphina",
            "Sirius",
            "Sorcha",
            "Saira",
            "Sarielle",
            "Serian",
            "Séverin",
            "Tavish",
            "Tearlach",
            "Terra",
            "Thalia",
            "Thaniel",
            "Theia",
            "Torian",
            "Torin",
            "Tressa",
            "Tristana",
            "Uriela",
            "Urien",
            "Ulyssia",
            "Vanora",
            "Vespera",
            "Vasilis",
            "Xanthus",
            "Xara",
            "Xylia",
            "Yadira",
            "Yseult",
            "Yakira",
            "Yeira",
            "Yeriel",
            "Yestin",
            "Zaira",
            "Zephyr",
            "Zora",
            "Zorion",
            "Zaniel",
            "Zarek",
        };
    }
}
