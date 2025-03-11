using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
        public void PickUpItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($"You found an item: {item.Name} (Heals: {item.HealingAmount})");
        }
        public void UseItem()
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
        public Weapon GetBestWeapon()
        {
            Weapon bestWeapon = null;
            if (Inventory.Count == 0) return new Weapon("Fists", 5);
            Inventory.Sort((a, b) => b.AttackPower.CompareTo(a.AttackPower));
            return Inventory[0];
        }
        public void ShowInventory()
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