using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        // Ensure only one entry point exists
        static void Main()
        {
            Game.Instance.Start();
        }
    }
}
