using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            player = new Player();
            Play();
        }
        public void Play()
        {
            while (player.Health > 0)
            {
                currentRoom = Room.GetRandomRoom();
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("                                                                        ");
                Console.WriteLine($"You enter a room. {currentRoom.GetDescription()}");
                currentRoom.Enter(player);
                
                if (player.Health <= 0)
                {
                    Console.WriteLine("You have died! Game Over!");
                    break;
                }

                Console.WriteLine("(i) Check Inventory, (p) Use Item, (c) Continue, (e) Exit Dungeon ");
                string input = Console.ReadLine()?.ToLower();
                while (input != "e")
                {
                    while (input != "e" && input != "c" && input != "i" && input != "p")
                    {
                        Console.WriteLine("Invalid action! (i) Check Inventory, (p) Use Item, (c) Continue, (e) Exit Dungeon ");
                        input = Console.ReadLine()?.ToLower();
                        if (input == "i")
                        {
                            player.ShowInventory();

                        }
                        else if (input == "p")
                        {
                            player.UseItem();
                        }
                        else if (input == "e")
                        {
                            Console.WriteLine("You exit the dungeon.");
                            break;
                        }
                    }
                }
            }
        }
    }
}