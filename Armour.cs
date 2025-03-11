using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Armour
    {
        public string Name { get; set; }
        public int Defence { get; set; }
        private static Random random = new Random();

        private static List<Armour> possibleArmours = new List<Armour>
        {
            new Armour("Leather Armour", 5),
            new Armour("Chainmail Armour", 10),
            new Armour("Plate Armour", 15),
            new Armour("Dragonhide Armour", 20),
            new Armour("Mithril Armour", 25),
            new Armour("Adamantite Armour", 30),
            new Armour("Runite Armour", 35),
            new Armour("Dragon Armour", 40),
            new Armour("God Armour", 50),
        };
        public Armour(string name, int defence)
        {
            Name = name;
            Defence = defence;
        }
        public static Armour GetRandomArmour()
        {
            return possibleArmours[random.Next(possibleArmours.Count)];
        }
        public override string ToString()
        {
            return Name + " (Defence: " + Defence + ")";
        }
    }
}
