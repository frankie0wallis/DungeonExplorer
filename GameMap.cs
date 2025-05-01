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

        public bool Move(string direction)
        {
            if (CurrentRoom.Exits.TryGetValue(direction, out Room nextRoom))
            {
                CurrentRoom = nextRoom;
                return true;
            }
            else
            {
                Console.WriteLine("You can't go that way.");
                return false;
            }
        }
        public void SetStart(Room room) => CurrentRoom = room; // Set the starting room
    }
}
