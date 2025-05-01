using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class GameMap
    {
        public Room CurrentRoom { get; private set; }

        public void Move(string direction)
        {
            direction = direction.ToLower(); // Normalize direction input
            Room nextRoom;
            if (CurrentRoom.Exits.TryGetValue(direction, out nextRoom))
            {
                CurrentRoom = nextRoom; // Move to the next room
                CurrentRoom.Enter(Game.Instance.Player); // Enter the new room
            }
            else Console.WriteLine("You can't go that way."); // Invalid direction message

        }
        public void SetStart(Room room) => CurrentRoom = room; // Set the starting room
    }
}
