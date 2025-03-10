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
        public Armour EquippedArmour { get; private set; }

        public void EquipArmour(Armour armour)
        {
            EquippedArmour = armour;
            Console.WriteLine($"You equipped {armour.Name} (Defence: {armour.Defence})");
        }
        public void TakeDamage(int damage)
        {
            int reducedDamage = EquippedArmour != null ? Math.Max(0, damage - EquippedArmour.Defence) : damage;
            Console.WriteLine($"You took {reducedDamage} damage! Health: {Health}");
        }

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
            foreach (var item in Items)
                Console.WriteLine($"- {item.Name} (Heals: {item.HealingAmount})");
            if (EquippedArmour != null)
                Console.WriteLine($"- Equipped Armour: {EquippedArmour}");
        }
    }
}