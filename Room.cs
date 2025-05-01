using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Room
    {
        public string Name { get; set; } // Name of the room  
        public string Description { get; set; } // Description of the room  
        public Dictionary<string, Room> Exits { get; } = new Dictionary<string, Room>(); // Exits from the room  
        public List<Monster> Monsters { get; } = new List<Monster>(); // List of monsters in the room  
        public List<Item> Items { get; } = new List<Item>(); // List of items in the room   
        private bool hasBeenExplored = false; // Flag to check if the room has been explored  

        public void SetExit(string direction, Room room) => Exits[direction.ToLower()] = room; // Set an exit to another room  

        public void Enter(Player player)
        {
            Console.WriteLine($"\n=== {Name} ==="); // Message when entering the room  
            Console.WriteLine(Description); // Display the room description  

            if (!hasBeenExplored)
            {
                if (Monsters.Count > 0)
                {
                    foreach (var monster in Monsters)
                    {
                        Console.WriteLine($"A {monster.Name} appears! (Health: {monster.Health}, Attack: {monster.AttackPower})");
                    }
                    foreach (var monster in Monsters.ToList())
                    {
                        while (monster.Health > 0 && player.Health > 0)
                        {

                            Console.WriteLine("What do you do? (attack / run)");
                            var input = Console.ReadLine().ToLower();
                            if (input == "attack")
                            {
                                player.Attack(monster);
                                if (monster.Health > 0)
                                    monster.Attack(player);
                            }
                            else if (input == "run")
                            {
                                Console.WriteLine("You flee from battle!");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Invalid command.");
                            }
                        }
                        if (monster.Health <= 0)
                        {
                            Console.WriteLine(monster.Name + " has been defeated!");
                            Monsters.Remove(monster);
                        }
                    }
                }

                if (Items.Count > 0)
                {
                    Console.WriteLine("You find some items:");
                    foreach (var item in Items)
                    {
                        Console.WriteLine("- " + item.GetDescription());
                        player.Inventory.AddItem(item);
                    }
                    hasBeenExplored = true; // Mark the room as explored after finding items

                }
                else
                {
                    Console.WriteLine("You have already explored this room."); // Message if the room has been explored  
                }
            }
        }
    }
}