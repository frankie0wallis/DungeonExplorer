using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Weapon
    {
        public string Name { get; private set; }
        public int AttackPower { get; private set; }
        private static Random random = new Random(); // Random generator for selecting random weapons
        public Weapon(string name, int attackpower) // Constructor to initialize a weapon with a name and attack power
        {
            Name = name;
            AttackPower = attackpower;
        }
        private static List<Weapon> possibleItems = new List<Weapon> // List of possible weapons with different attack values
        {
            new Weapon("Sword", 15),
            new Weapon("Axe", 15),
            new Weapon("Bow", 20),
            new Weapon("Dagger", 10),
            new Weapon("Staff", 25),
            new Weapon("Mace", 30),
            new Weapon("Spear", 35),
            new Weapon("Crossbow", 35),
            new Weapon("Halberd", 40),
            new Weapon("Scythe", 25),
            new Weapon("Flail", 30),
            new Weapon("Katana", 50),
            new Weapon("Boomerang", 5),
            new Weapon("Shuriken", 10),
            new Weapon("Kunai", 10),
            new Weapon("Trident of Poseidon", 75),
        };
        public static Weapon GetRandomWeapon() // Returns a random weapon from the list of possible weapons
        {
            return possibleItems[random.Next(possibleItems.Count)];
        }
    }
}