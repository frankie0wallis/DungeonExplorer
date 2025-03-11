using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Combat
    {
        public static void Fight(Player player, Monster monster)
        {
            Console.WriteLine($"A {monster.Name} appears! It has {monster.Health} health and {monster.Attack} attack power!");

            while (player.Health > 0 && monster.Health > 0)
            {
                Console.WriteLine("(a) Attack, (i) Check Inventory, (p) Use Item, (r) Run Away");
                string input = Console.ReadLine()?.ToLower();

                if (input == "a")
                {
                    Weapon weapon = player.GetBestWeapon();
                    monster.Health -= weapon.AttackPower;
                    Console.WriteLine($"You attacked the {monster.Name} with {weapon.Name} for {weapon.AttackPower} damage! It has {monster.Health} health left!");

                    if (monster.Health <= 0)
                    {
                        Console.WriteLine($"You defeated the {monster.Name}!");
                        return;
                    }
                }
                else if (input == "i")
                {
                    player.ShowInventory();
                }
                else if (input == "p")
                {
                    player.UseItem();
                }
                else if (input == "r")
                {
                    Console.WriteLine("You ran away!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid action!");
                }
            }
        }
    }
}
