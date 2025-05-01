using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Monster : Creature
    {
        public int AttackPower { get; protected set; } // Attack power of the monster
        public override void TakeDamage(int amount)
        {
            Health -= amount; // Reduce health by the damage taken
            Console.WriteLine(Name + " takes " + amount + " damage. Remaining HP: " + Health); // Display damage message
        }
    }
    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "Goblin"; // Set the name of the monster
            Health = 20; // Set the initial health of the monster
            AttackPower = 5; // Set the attack power of the monster
        }
        public override void Attack(Creature target)
        {
            Console.WriteLine("The goblin snarls and attacks!"); // Display attack message
            target.TakeDamage(AttackPower); // Apply damage to the target
        }
    }
    public class Orc : Monster
    {
        public Orc()
        {
            Name = "Orc"; // Set the name of the monster
            Health = 30; // Set the initial health of the monster
            AttackPower = 8; // Set the attack power of the monster
        }
        public override void Attack(Creature target)
        {
            Console.WriteLine("The orc roars and charges!"); // Display attack message
            target.TakeDamage(AttackPower); // Apply damage to the target
        }
    }
    public class Dragon : Monster
    {
        public Dragon()
        {
            Name = "Dragon"; // Set the name of the monster
            Health = 50; // Set the initial health of the monster
            AttackPower = 15; // Set the attack power of the monster
        }
        public override void Attack(Creature target)
        {
            Console.WriteLine("The dragon breathes fire!"); // Display attack message
            target.TakeDamage(AttackPower); // Apply damage to the target
        }
    }
}

