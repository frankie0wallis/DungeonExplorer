using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        public List<Item> Items { get; } = new(); // List to hold items in the inventory
        private Weapon equippedWeapon; // Variable to hold the equipped weapon

        public void AddItem (Item item) => Items.Add(item); // Method to add an item to the inventory
        public void EquipWeapon(Weapon weapon) => equippedWeapon = weapon; // Method to equip a weapon
        public Weapon GetEquippedWeapon() => equippedWeapon; // Method to get the currently equipped weapon

        public void Use(string itemName)
        {
            var item = Items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower()); // Find the item by name
            if (item != null)
            {
                item.use(Game.Instance.Player); // Use the item
                Items.Remove(item); // Remove the item from the inventory after use
            }
            else
            {
                Console.WriteLine($"Item not found in inventory."); // Item not found message
            }
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
                Console.WriteLine("-" item.GetDescription()); // List all items in the inventory
            }
        }
    }
}
