using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private static Random random = new Random();

        public Room(string description)
        {
            this.description = description;
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
                    Console.WriteLine("You enter the room and find a chest.");
                    player.PickUpItem(Item.GetRandomItem());
                    break;
                case 2:
                    Console.WriteLine("You enter the room and find a monster.");
                    player.Attack();
                    break;
                case 3:
                    Console.WriteLine("You enter the room and find a trap.");
                    player.TakeDamage(10);
                    break;
                case 4:
                    Console.WriteLine("You enter the room and find nothing.");
                    break;
            }
        }
    }
}