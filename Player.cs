﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Player
    {
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
            if (EquippedArmour == null)
            {
                Health -= damage;
                Console.WriteLine($"You took {damage} damage! Health: {Health}");
                return;
            }
            else if (EquippedArmour != null)
            {
                int ReducedDamage = damage - EquippedArmour.Defence;
                if (ReducedDamage < 0) ReducedDamage = 0;
                Health -= ReducedDamage;
                Console.WriteLine($"You took {ReducedDamage} damage! Health: {Health}");
            }
        }
        public int GetTotalDefence()
        {
            return EquippedArmour != null ? EquippedArmour.Defence : 0;
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
        public Armour GetBestArmour()
        {
            Armour bestArmour = null;
            if (EquippedArmour == null) return new Armour("None", 0);
            if (EquippedArmour.Defence > bestArmour.Defence) bestArmour = EquippedArmour;
            return bestArmour;
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