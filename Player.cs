using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public Inventory Inventory { get; private set; } = new Inventory(); // Player's inventory to hold items
        public override void Attack(Creature target)
        {
            var weapon = Inventory.GetEquippedWeapon(); // Get the equipped weapon from the inventory
            int damage = weapon?.AttackPower ?? 5; // Calculate damage based on the weapon's attack power
            Console.WriteLine($"You attack {target.Name} for {damage} damage!"); // Display attack message
            target.TakeDamage(damage); // Apply damage to the target
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage; // Reduce health by the damage taken
            Console.WriteLine($"{Name} takes {damage} damage! Remaining Health: {Health}"); // Display damage message
        }

        public void Heal(int amount) => Health += amount; // Heal the player by a specified amount
    }
}