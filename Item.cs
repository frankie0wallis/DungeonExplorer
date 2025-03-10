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
        private static Random random = new Random();

        private static List<Item> possibleitems = new List<Item>
        {
            new Item("Small Health Potion", 10),
            new Item("Medium Health Potion", 20),
            new Item("Large Health Potion", 30),
            new Item("Legendary Health Potion", 50),
            new Item("Revive Scroll", 100),
        };

        public Item(string name, int healingamount)
        {
            Name = name;
            HealingAmount = healingamount;
        }

        public static Item GetRandomItem()
        {
            return possibleitems[random.Next(possibleitems.Count)];
        }
    }
}
