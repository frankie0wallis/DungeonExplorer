using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        public string Name { get; set; }
        public int HealingAmount { get; set; }
        private static Random random = new Random(); // Random generator for selecting random items

        private static List<Item> possibleitems = new List<Item>
        {
            new Item("Small Health Potion", 10),
            new Item("Medium Health Potion", 20),
            new Item("Large Health Potion", 30),
            new Item("Legendary Health Potion", 50),
            new Item("Revive Scroll", 100),
        };

        public Item(string name, int healingamount) // Constructor to initialize an item with a name and healing amount
        {
            Name = name;
            HealingAmount = healingamount;
        }

        public static Item GetRandomItem()// Returns a random item from the list of possible items
        {
            return possibleitems[random.Next(possibleitems.Count)];
        }
    }
}
