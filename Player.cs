using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public Inventory Inventory { get; private set; } = new Inventory(); // Player's inventory to hold items
        public int BaseAttackPower { get; set; } // Player's inherent attack strength
        public double DodgeChance { get; set; }  // Chance to dodge an attack
        public override void Attack(Creature target)
        {
            var weapon = Inventory.GetEquippedWeapon(); // Get the equipped weapon from the inventory
            int damage = weapon != null ? weapon.AttackPower : 5; // Calculate damage based on the weapon's attack power
            Console.WriteLine("You attack " + target.Name + " for " + damage + " damage!"); // Display attack message
            target.TakeDamage(damage); // Apply damage to the target
        }

        public override void TakeDamage(int amount)
        {
            Random rng = new Random();
            if (rng.NextDouble() < DodgeChance)
            {
                Console.WriteLine($"{Name} dodged the attack!");
                return;
            }

            Health -= amount;
            Console.WriteLine($"{Name} takes {amount} damage! Remaining Health: {Health}");
        }

        public void Heal(int amount) // Heal the player by a specified amount
        {
            Health += amount; // Increase health by the healing amount
            Console.WriteLine($"{Name} heals for {amount}. Current Health: {Health}"); // Display healing message
        }
    }
}