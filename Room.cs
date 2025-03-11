using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private static Random random = new Random();
        private static List<string> roomDescriptions = new List<string>
        {
            ("A dimly lit chamber with torches flickering on the walls"),
            ("A damp cave with the sound of dripping water echoing through the darkness."),
            ("A grand hall with broken statues and faded murals of ancient battles."),
            ("A narrow corridor filled with cobwebs and the distant sound of scurrying rats."),
            ("A mysterious library filled with ancient tomes and glowing runes on the floor."),
            ("An empty room with an unsettling lack of danger."),
        };

        public Room()
        {
            description = roomDescriptions[random.Next(roomDescriptions.Count)];
        }

        public string GetDescription()
        {
            return description;
        }

        public void Enter(Player player)
        {
            int eventRoll = random.Next(1, 5);
            switch (eventRoll)
            {
                case 1:
                    Console.WriteLine("A Monster Attacks You!");
                    Monster monster = Monster.GetRandomMonster();
                    Combat.Fight(player, monster);
                    break;
                case 2:
                    Console.WriteLine("You Found A Weapon!");
                    player.PickUpWeapon(Weapon.GetRandomWeapon());
                    break;
                case 3:
                    Console.WriteLine("You Found Some Armour!");
                    player.EquipArmour(Armour.GetRandomArmour());
                    break;
                case 4:
                    Console.WriteLine("You Found An Item!.");
                    player.PickUpItem(Item.GetRandomItem());
                    break;
            }
        }
        public static Room GetRandomRoom()
        {
            return new Room();
        }
    }
}