using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    public static class DebugHelper
    {
        public static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Debug.WriteLine($"Assertion Failed: {message}");
                Console.WriteLine($"[DEBUG] Assertion Failed: {message}");
                Debugger.Break(); // Triggers a breakpoint in debug mode
            }
        }
    }
}