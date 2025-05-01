using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        public List<Item> Items { get; } = new List<Item>(); // List to hold items in the inventory
        private Weapon equippedWeapon; // Variable to hold the equipped weapon

        public void AddItem (Item item) // Method to add an item to the inventory
        {
            if (item == null)
            {
                Console.WriteLine("Attempted to add a null item.");
                return;
            }
            Items.Add(item);
        }
        public void EquipWeapon(Weapon weapon) // Method to equip a weapon
        {
            if (weapon == null)
            {
                Console.WriteLine("Invalid weapon.");
                return;
            }
            equippedWeapon = weapon;
        }
        public Weapon GetEquippedWeapon() => equippedWeapon; // Method to get the currently equipped weapon

        // Inventory.cs
        public void Use(string itemName, Player player)
        {
            var item = Items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
            if (item != null)
            {
                item.Use(player);
                Items.Remove(item);
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
            }
        }
        public int GetTotalWeaponAttack()
        {
            return equippedWeapon != null ? equippedWeapon.AttackPower : 0;
        }

        public void ListItems()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Inventory is empty."); // Message if inventory is empty  
                return;
            }

            Console.WriteLine("Inventory Items:");
            foreach (var item in Items)
            {
                Console.WriteLine("- " + item.GetDescription()); // Corrected syntax by adding '+' for string concatenation  
            }
        }
    }
}
