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
            Play(); // Starts the main game loop
        }
        // Main game loop where the player explores rooms
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

                Console.WriteLine("Do you want to continue exploring? (y/n)");
                string input;
                do
                {
                    input = Console.ReadLine()?.ToLower(); // Get user input
                    if (input != "y" && input != "n") // Validate input
                    {
                        Console.WriteLine("Invalid input. Please enter 'y' to continue or 'n' to exit.");
                    }
                } while (input != "y" && input != "n");

                if (input == "n") // Exit the game if player chooses not to continue
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
                    
             
               
            }
        }
    }
}