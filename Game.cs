using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;

namespace DungeonExplorer
{
    public class Game
    {
        public static Game Instance { get; } = new Game(); // Singleton instance of the game
        public Player Player { get; private set; } // Player instance
        public GameMap Map { get; private set; } // Game map instance
        private static Random random = new Random(); // Random number generator

        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.Write("Enter your character's name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Hero";
            }

            Console.WriteLine("Choose your class:");
            Console.WriteLine("1. Warrior (more health, stronger attacks)");
            Console.WriteLine("2. Rogue (more speed, better dodge chance)");
            Console.Write("Enter class (warrior/rogue): ");
            string playerClass = Console.ReadLine()?.ToLower();

            if (playerClass == "warrior")
            {
                Player = new Player
                {
                    Name = name,
                    Health = 120,
                    BaseAttackPower = 15,
                    DodgeChance = 0.1
                };
            }
            else
            {
                Player = new Player
                {
                    Name = name,
                    Health = 100,
                    BaseAttackPower = 10,
                    DodgeChance = 0.3
                };
            }

            Map = new GameMap();

            var r1 = new Room();
            r1.Name = "Goblin Den";
            r1.Description = "A dark cave crawling with goblins.";
            var r2 = new Room();
            r2.Name = "Dragon Lair";
            r2.Description = "A scorched chamber filled with treasure.";
            var r3 = new Room();
            r3.Name = "Enchanted Forest";
            r3.Description = "A mystical forest glowing with energy.";
            var r4 = new Room();
            r4.Name = "Ancient Ruins";
            r4.Description = "Ruins filled with forgotten relics and dangers.";

            r1.SetExit("east", r2);
            r2.SetExit("west", r1);
            r1.SetExit("north", r3);
            r3.SetExit("south", r1);
            r2.SetExit("north", r4);
            r4.SetExit("south", r2);

            r1.Monsters.AddRange(GenerateRandomMonsters());
            r2.Monsters.AddRange(GenerateRandomMonsters());
            r3.Monsters.AddRange(GenerateRandomMonsters());
            r4.Monsters.AddRange(GenerateRandomMonsters());

            r1.Items.AddRange(GenerateRandomItems());
            r2.Items.AddRange(GenerateRandomItems());
            r3.Items.AddRange(GenerateRandomItems());
            r4.Items.AddRange(GenerateRandomItems());

            Map.SetStart(r1);
            EnterRoomWithCombat(Map.CurrentRoom);
            ShowHelp();

            while (Player.Health > 0)
            {
                Console.WriteLine("Enter a command (type 'help' to see options):");

                var input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToLower();
                    if (input == "help")
                    {
                        ShowHelp();
                        continue;
                    }
                    if (input == "inventory")
                    {
                        Player.Inventory.ListItems();
                        continue;
                    }
                    else if (input == "north" || input == "south" || input == "east" || input == "west")
                    {
                        if (Map.Move(input))
                        {
                            EnterRoomWithCombat(Map.CurrentRoom);
                        }
                        continue;
                    }
                    else if (input.StartsWith("use "))
                    {
                        string itemName = input.Substring(4).Trim();
                        if (!string.IsNullOrEmpty(itemName))
                        {
                            Player.Inventory.Use(itemName, Player);
                        }
                        continue;
                    }
                }
            }
            Console.WriteLine("Game Over!"); // Game over message
        }

        private void EnterRoomWithCombat(Room room)
        {
            room.Enter(Player);
            foreach (var monster in room.Monsters.ToList())
            {
                Console.WriteLine($"A wild {monster.Name} appears! HP: {monster.Health}, Attack: {monster.AttackPower}");
                while (monster.Health > 0 && Player.Health > 0)
                {
                    Console.WriteLine("Choose action: (attack/run)");
                    var action = Console.ReadLine()?.ToLower();

                    if (action == "run")
                    {
                        Console.WriteLine("You fled from battle!");
                        return;
                    }
                    else if (action == "attack")
                    {
                        int weaponAttack = Player.Inventory.GetTotalWeaponAttack();
                        int totalAttack = Player.BaseAttackPower + weaponAttack;
                        monster.Health -= totalAttack;
                        Console.WriteLine($"You hit the {monster.Name} for {totalAttack} damage. Monster HP: {monster.Health}");

                        if (monster.Health <= 0)
                        {
                            Console.WriteLine($"You defeated the {monster.Name}!");
                            room.Monsters.Remove(monster);
                            break;
                        }

                        if (random.NextDouble() > Player.DodgeChance)
                        {
                            Player.Health -= monster.AttackPower;
                            Console.WriteLine($"The {monster.Name} hits you for {monster.AttackPower} damage. Your HP: {Player.Health}");
                        }
                        else
                        {
                            Console.WriteLine("You dodged the attack!");
                        }
                    }
                }
            }
        }

        private List<Monster> GenerateRandomMonsters()
        {
            var monsters = new List<Monster>();
            int count = random.Next(1, 4);
            for (int i = 0; i < count; i++)
            {
                int type = random.Next(3);
                Monster m;
                switch (type)
                {
                    case 0: m = new Goblin(); break;
                    case 1: m = new Orc(); break;
                    case 2: m = new Dragon(); break;
                    default: m = new Goblin(); break;
                }
                monsters.Add(m);
            }
            return monsters; // Return the list of monsters
        }

        private List<Item> GenerateRandomItems()
        {
            var allItems = new List<Item>();
            allItems.Add(new Weapon { Name = "Iron Sword", AttackPower = 10 });
            allItems.Add(new Weapon { Name = "Steel Axe", AttackPower = 15 });
            allItems.Add(new Weapon { Name = "Enchanted Dagger", AttackPower = 12 });
            allItems.Add(new Potion { Name = "Small Healing Potion", HealingAmount = 20 });
            allItems.Add(new Potion { Name = "Large Healing Potion", HealingAmount = 40 });
            allItems.Add(new Potion { Name = "Elixir of Life", HealingAmount = 60 });

            return allItems.OrderBy(x => random.Next()).Take(random.Next(1, 4)).ToList();
        }

        private void ShowHelp()
        {
            Console.WriteLine("========== HELP MENU ==========");
            Console.WriteLine("Move:         north | south | east | west");
            Console.WriteLine("Inventory:    inventory");
            Console.WriteLine("Use Item:     use [item name]");
            Console.WriteLine("Show Help:    help");
            Console.WriteLine("================================");
        }
    }
}
