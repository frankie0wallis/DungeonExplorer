using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Player
    {
        public int Health { get; private set; } = 100; // Player's health, starts at 100
        public List<Weapon> Inventory { get; private set; } = new List<Weapon>(); // List of weapons in inventory
        public List<Item> Items { get; private set; } = new List<Item>(); // List of items in inventory
        public Armour EquippedArmour { get; private set; } // The player's currently equipped armor

        public void EquipArmour(Armour armour)
        {
            EquippedArmour = armour;
            Console.WriteLine($"You equipped {armour.Name} (Defence: {armour.Defence})");
        }
        public void TakeDamage(int damage) // Apply damage to the player, reducing health based on armor defense
        {
            if (EquippedArmour == null)
            {
                Health -= damage; // Full damage taken if no armor
                Console.WriteLine($"You took {damage} damage! Health: {Health}");
                return;
            }
            else if (EquippedArmour != null)
            {
                int ReducedDamage = damage - EquippedArmour.Defence;
                if (ReducedDamage < 0) ReducedDamage = 0; // Ensure damage is not negative
                Health -= ReducedDamage;
                Console.WriteLine($"You took {ReducedDamage} damage! Health: {Health}");
            }
        }
        public int GetTotalDefence() // Get the total defense value from the equipped armor
        {
            return EquippedArmour != null ? EquippedArmour.Defence : 0;
        }

        public void PickUpWeapon(Weapon weapon) // Pick up a weapon and add it to the inventory
        {
            Inventory.Add(weapon);
            Console.WriteLine($"You found an item: {weapon.Name} (Attack Power: {weapon.AttackPower})");
        }
        public void PickUpItem(Item item) // Pick up an item and add it to the inventory
        {
            Items.Add(item);
            Console.WriteLine($"You found an item: {item.Name} (Heals: {item.HealingAmount})");
        }
        public void UseItem() // Use an item to heal the player
        {
            if (Items.Count > 0)
            {
                Item item = Items[0];
                Health += item.HealingAmount;
                Items.RemoveAt(0);
                Console.WriteLine($"You used {item.Name} and healed {item.HealingAmount} health! Health: {Health}");
            }
            else
            {
                Console.WriteLine("You have no items to use.");
            }
        }
        public Armour GetBestArmour() // Get the best armor based on defense value
        { 
            Armour bestArmour = null;
            if (EquippedArmour == null) return new Armour("None", 0);
            if (EquippedArmour.Defence > bestArmour.Defence) bestArmour = EquippedArmour;
            return bestArmour;
        }
        public Weapon GetBestWeapon() // Get the best weapon based on attack power
        {
            Weapon bestWeapon = null;
            if (Inventory.Count == 0) return new Weapon("Fists", 5); // Default weapon if none found
            Inventory.Sort((a, b) => b.AttackPower.CompareTo(a.AttackPower)); // Sort weapons by attack power
            return Inventory[0]; // Return the most powerful weapon
        }
        public void ShowInventory() // Display player's inventory
        {
            Console.WriteLine("Inventory:");
            foreach (var weapon in Inventory)
                Console.WriteLine($"- {weapon.Name} (Attack: {weapon.AttackPower})");
            foreach (var item in Items)
                Console.WriteLine($"- {item.Name} (Heals: {item.HealingAmount})");
            if (EquippedArmour != null)
                Console.WriteLine($"- Equipped Armour: {EquippedArmour}");
        }
    }
}