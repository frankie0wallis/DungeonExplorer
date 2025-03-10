using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Item
    {
        public string Name { get; private set; }
        public int AttackPower { get; private set; }
        private static Random random = new Random();
        public Item(string name, int attackpower)
        {
            Name = name;
            AttackPower = attackpower;
        }
        private static List<Item> possibleItems = new List<Item>
        {
            new Item("Sword", 15),
            new Item("Axe", 15),
            new Item("Bow", 20),
            new Item("Dagger", 10),
            new Item("Staff", 25),
            new Item("Mace", 30),
            new Item("Spear", 35),
            new Item("Crossbow", 35),
            new Item("Halberd", 40),
            new Item("Scythe", 25),
            new Item("Flail", 30),
            new Item("Katana", 50),
            new Item("Boomerang", 5),
            new Item("Shuriken", 10),
            new Item("Kunai", 10),
            new Item("Trident of Poseidon", 75),
        };
        public static Item GetRandomItem()
        {
            return possibleItems[random.Next(possibleItems.Count)];
        }
    }
}