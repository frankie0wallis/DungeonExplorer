using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; } = 100;
        public List<Weapon> Inventory { get; private set; } = new List<Weapon>();
        public List<Item> Items { get; private set; } = new List<Item>();

        public void PickUpWeapon(Weapon weapon)
        {
            Inventory.Add(weapon);
            Console.WriteLine($"You found an item: {weapon.Name} (Attack Power: {weapon.AttackPower})");
        }

        public string ShowInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var weapon in Inventory)
                Console.WriteLine($"- {weapon.Name} (Attack: {weapon.AttackPower})");
            foreach (var potion in Item)
                Console.WriteLine($"- {potion.Name} (Heals: {potion.HealingAmount})");
            if (EquippedArmour != null)
                Console.WriteLine($"- Equipped Armour: {EquippedArmour}");
        }
    }
}