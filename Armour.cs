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
        private static Random random = new Random(); // Random generator for selecting random armour

        private static List<Armour> possibleArmours = new List<Armour> // List of possible armour pieces with different defence values
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
        public Armour(string name, int defence) // Constructor to initialize an armour piece with a name and defence value
        {
            Name = name;
            Defence = defence;
        }
        public static Armour GetRandomArmour() // Returns a random armour piece from the list of possible armours
        {
            return possibleArmours[random.Next(possibleArmours.Count)];
        }
        public override string ToString() // Override ToString method to display armour name and defence value
        {
            return Name + " (Defence: " + Defence + ")";
        }
    }
}
