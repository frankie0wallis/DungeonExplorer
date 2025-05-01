using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Item : ICollectable
    {
        public string Name { get; set; } // Name of the item
        public abstract void Use(Player player); // Abstract method to use the item
        public abstract string GetDescription(); // Abstract method to get the item's description
    }
    public class Potion : Item
    {
        public int HealingAmount { get; set; } // Amount of health the potion restores
        public override void Use(Player player)
        {
            player.Heal(HealingAmount); // Restore health to the player
            Console.WriteLine($"{Name} heals for {HealingAmount}"); // Message after using the potion
        }

        public override string GetDescription() => $"{Name}: Restores {HealingAmount} health."; // Description of the potion
    }
    public class Weapon : Item
    {
        public int AttackPower { get; set; } // Attack power of the weapon
        public override void Use(Player player)
        {
            player.Inventory.EquipWeapon(this); // Equip the weapon to the player
            Console.WriteLine($"{Name} equipped with {AttackPower} power."); // Message after equipping the weapon
        }

        public override string GetDescription() => $"{Name}: Attack Power {AttackPower}."; // Description of the weapon
    }
}
